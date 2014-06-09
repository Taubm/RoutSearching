using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {

        Graph grph = new Graph();
        prefs pref;
        
        public Connect Con = new Connect("", "", "", "");
        Connection start_end = new Connection(new Point(0, 0), new Point(0, 0),0);
        Connection cr_con = new Connection(new Point(0, 0), new Point(0, 0),0);

        //Функция поиска кратчайшего пути, возвращает грани, которые можно вывести на экран
        static List<Connection> get_path(
                                        Connection _start_end, //Начальная и конечная точки
                                        Graph _g)              //Исследуемый граф
        {
            //Список вершин графа со стоимостью
            List<S_point> ch_pnts = new List<S_point>();
            foreach (S_point p in _g.Nodes) ch_pnts.Add(new S_point(p.pnt,0,p.name));

            List<Connection> result = new List<Connection>();
            double fin_cost = 0;

            //Сформируем начальный путь
            snake first = new snake(get_pathes(_start_end.p1, _g.Lines), 0);
            first.head = _start_end.p1;
            List<snake> snakes = new List<snake>();
            snakes.Add(first);
            /*
             * Цикл формирует все возможные пути. Когда будет найден первый путь до конечной точки, будет назначена цена пути.
             * Оставшиеся пути будут продолжать формироваться до тех пор, пока стоимость каждого из них не превысит
             * стоимость уже найденного пути.
             */
            do {
                int i = snakes.Count-1;
                if (snakes.Count > 0)
                do {
                    int j = snakes[i].pathes.Count-1;
                    if (snakes[i].pathes.Count>0)
                    do {
                        Point cur_pnt = new Point();
                        double tmp_cost = snakes[i].cost + snakes[i].pathes[j].cost;
                        if (snakes[i].pathes[j].p1 == snakes[i].head) cur_pnt = snakes[i].pathes[j].p2; else cur_pnt = snakes[i].pathes[j].p1;

                        if ((get_s_point(cur_pnt, ch_pnts).cost > tmp_cost || get_s_point(cur_pnt, ch_pnts).cost == 0) && (tmp_cost<fin_cost || fin_cost==0))
                        {
                            if (cur_pnt == _start_end.p2 && (fin_cost > tmp_cost || fin_cost==0))
                            {
                                fin_cost = tmp_cost;
                                result = snakes[i].body;
                                result.Add(snakes[i].pathes[j]);
                            }
                            else

                                if (cur_pnt != snakes[i].neck)
                                {
                                    snake tmp_snake = new snake(get_pathes(cur_pnt, _g.Lines), tmp_cost);
                                    foreach (Connection c in snakes[i].body) tmp_snake.body.Add(c);
                                    tmp_snake.body.Add(snakes[i].pathes[j]);
                                    tmp_snake.neck = snakes[i].head;
                                    tmp_snake.head = cur_pnt;
                                    set_s_point_cost(cur_pnt, tmp_cost, ch_pnts);
                                    snakes.Add(tmp_snake);
                                }
                        }
                        snakes[i].pathes.RemoveAt(j);
                        j--;
                    } while(j>=0);
                    snakes.RemoveAt(i);
                    i--;
                } while(i>=0);

            } while (snakes.Count!=0);
            return result;
        }

        //Функция вернет именованную вершину с указанными координатами из списка
        static S_point get_s_point(Point _p, List<S_point> _s_pnts)
        {
            S_point result = null;
            int i=0;
            do {
                if (_s_pnts[i].pnt==_p) result=_s_pnts[i];
                i++;
            }
            while (i < _s_pnts.Count && result == null);
            return result;
        }

        //Функция установит стоимость именованной вершины
        static void set_s_point_cost(Point _p, double c, List<S_point> _s_pnts)
        {
            int i = 0;
            do
            {
                if (_s_pnts[i].pnt == _p) _s_pnts[i].cost = c;
                i++;
            }
            while (i < _s_pnts.Count - 1 && _s_pnts[i].pnt != _p);
        }

        //Функция вернет все связи, которые связанны с переданной вершиной
        static List<Connection> get_pathes(Point _p, List<Connection> _cons)
        {
            List<Connection> result = new List<Connection>();
            foreach (Connection con in _cons) 
                if (con.p1 == _p || con.p2 == _p) result.Add(con);
            return result;
        }

        //Функция проверит равенство отмеченной точки и вершины полигона с учетом погрешности в n пикселей
        static Boolean check_point(Point _p1, Point _p2)
        {
            int n = 8;
            if (((_p1.X < _p2.X + n) && (_p1.X > _p2.X - n)) && ((_p1.Y < _p2.Y + n) && (_p1.Y > _p2.Y - n))) return true;
            else return false;
        }

        //Функция найдет и удалит указанную связь из списка
        static Boolean delete_exist_line(Connection _con, List<Connection> _cons)
        {
            Boolean result = false;
            int i = _cons.Count - 1;
            if (i >= 0) do
                {
                    if ((_con.p1 == _cons[i].p1 && _con.p2 == _cons[i].p2) || (_con.p1 == _cons[i].p2 && _con.p2 == _cons[i].p1))
                    {
                        result = true;
                        _cons.RemoveAt(i);
                    }
                    i--;
                } while (result == false && i >= 0);
            return result;
        }

        //Функция найдет по указанным координатам и удалит именованную вершину из списка
        static S_point delete_exist_point(Point _p, List<S_point> _pts)
        {
            S_point result = null;
            int i = _pts.Count - 1;
            if (i>=0) do
            {
                if (check_point(_p, _pts[i].pnt))
                {
                    result = _pts[i];
                    _pts.RemoveAt(i);
                }
                i--;
            } while (result == null && i >= 0);
            return result;
        }

        //Функция найдет и удалит связи, которые связывают указанную вершину с другими
        static void delete_node(S_point _p, List<Connection> _cons)
        {
            for (int i=_cons.Count-1; i>=0; i--)
                    if (_cons[i].p1==_p.pnt || _cons[i].p2==_p.pnt)
                        _cons.RemoveAt(i);
        }

        //Функция вернет длину связи между вершинами, т.е. стоимость
        static double calc_cost(Point _p1, Point _p2)
        {
            double result = Math.Sqrt(Math.Pow(Math.Abs(_p2.X - _p1.X), 2) + Math.Pow(Math.Abs(_p2.Y - _p1.Y), 2));
            return result;
        }

        //Функция начертит граф
        static void print_graph(Graph _g, Connection _cr_con, Connection _path, PictureBox _paint)
        {
            Bitmap bmp = new Bitmap(_paint.Width, _paint.Height);
            Graphics _gr = Graphics.FromImage(bmp);

            _gr.Clear(Color.White);
            foreach (S_point _p in _g.Nodes)
            {
                _gr.FillEllipse(Brushes.Black, _p.pnt.X - 4, _p.pnt.Y - 4, 8, 8);
                _gr.DrawString(_p.name, new Font("Arial", 8), Brushes.Black, _p.pnt.X-6, _p.pnt.Y + 8);
            }
            foreach(Connection _c in _g.Lines)
                _gr.DrawLine(new Pen(Color.Black), _c.p1, _c.p2);
            if (_cr_con.p1 != new Point(0, 0)) _gr.DrawEllipse(new Pen(Color.Turquoise),_cr_con.p1.X-8, _cr_con.p1.Y-8, 16, 16);
            if (_path.p1 != new Point(0, 0)) _gr.DrawEllipse(new Pen(Color.Red), _path.p1.X - 8, _path.p1.Y - 8, 16, 16);
            if (_path.p2 != new Point(0, 0)) _gr.DrawEllipse(new Pen(Color.Red), _path.p2.X - 8, _path.p2.Y - 8, 16, 16);

            _paint.Image = bmp;
        }

        //Класс для связей между вершинами - начальная вершина, конечная вершина и стоимость связи
        [Serializable()]
        public class Connection
        {
            public Connection(Point _p1, Point _p2, double _cost)
            {
                p1 = _p1;
                p2 = _p2;
                cost = _cost;
            }
            public Point p1;
            public Point p2;
            public double cost;
        }

        //Класс для именованной вершины - координаты, стоимость и метка
        [Serializable()]
        public class S_point
        {
            public S_point(Point _p, double _cost, string _name)
            {
                pnt = _p;
                cost = _cost;
                name = _name;
            }
            public double cost;
            public Point pnt;
            public string name;
        }

        //Класс-змейка для поиска минимального маршрута
        public class snake
        {
            public snake(List<Connection> _pathes, double _cost)
            {
                cost = _cost;
                pathes = _pathes;
            }
            public double cost = 0; //стоимость
            public Point head;      //последняя нода
            public Point neck;      //предпоследняя нода
            public List<Connection> pathes = new List<Connection>(); //связи, исходящие из последней ноды
            public List<Connection> body = new List<Connection>();   //все пройденные связи
        }

        //Граф
        [Serializable()]
        public class Graph
        {
            public Graph(){}
            public int point_num = 0; //номер последней ноды, используется для автоматической расстановки меток точек
            public List<S_point> Nodes = new List<S_point>(); 
            public List<Connection> Lines = new List<Connection>();
        }

        //Класс для соединения с БД
        [Serializable()]
        public class Connect {
            public Connect(string _name, string _host, string _user, string _pass)
            {
                name = _name;
                host = _host;
                user = _user;
                pass = _pass;
            }
            public string get() {
                string result = "Database="+name+";Data Source="+host+";User Id="+user+";Password="+pass;
                return result;
            }

            public void set_name(string s) 
            {
                name = s;
            }
            public void set_host(string s)
            {
                host = s;
            }
            public void set_user(string s)
            {
                user = s;
            }
            public void set_pass(string s)
            {
                pass = s;
            }
            public string get_name()
            {
                return name;
            }
            public string get_host()
            {
                return host;
            }
            public string get_user()
            {
                return user;
            }
            public string get_pass()
            {
                return pass;
            }
            private string name ="";
            private string host = "";
            private string user = "";
            private string pass = "";
        }

        public Form1()
        {
            InitializeComponent();
            pref = new prefs();
            pref.Owner = this;
            if (File.Exists("prefs"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream inputStream = File.OpenRead("prefs");
                try
                {
                    Con = (Connect)formatter.Deserialize(inputStream);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка:\n" + ex.Message, "",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                inputStream.Close();
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream outputStream = File.OpenWrite("prefs");
                formatter.Serialize(outputStream, Con);
                outputStream.Close();
            }
        }
        /*
         * Обработка клика мышкой по полю для рисования, выполняет различные действия в зависимости от режима
         * в режиме point проставляет по клику ноды
         * в режиме line создает связи между нодами
         * в режиме path устанавливает точки, между которыми будет рассчитываться кратчайший путь
         */
        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            S_point pnt = new S_point(new Point(e.X, e.Y),0,point_name_man.Text);
            switch ((Canvas.Tag as String))
            {
                case "point":
                    S_point p = delete_exist_point(pnt.pnt, grph.Nodes);
                    if (p == null)
                    {
                        grph.Nodes.Add(pnt);
                        point_name_man.Text = "";
                    }
                    else delete_node(p, grph.Lines);
                    break;
                case "line":
                    int i=0;
                    if (grph.Nodes.Count > 1)
                    {
                        do
                        {
                            if (check_point(pnt.pnt, grph.Nodes[i].pnt)) pnt = grph.Nodes[i];
                            i++;
                        } while (i < grph.Nodes.Count && pnt != grph.Nodes[i - 1]);
                        if (pnt != grph.Nodes[i - 1]) break;
                        if (cr_con.p1 == new Point(0, 0)) cr_con.p1 = pnt.pnt;
                        else
                        {
                            if (cr_con.p1 == pnt.pnt) cr_con.p1 = new Point(0, 0);
                            else
                            {
                                cr_con.p2 = pnt.pnt;
                                cr_con.cost = calc_cost(cr_con.p1, cr_con.p2);
                                if (!delete_exist_line(cr_con, grph.Lines)) grph.Lines.Add(cr_con);
                                cr_con = new Connection(new Point(0, 0), new Point(0, 0), 0);
                            }
                        }
                    }
                    else System.Windows.Forms.MessageBox.Show("Ошибка:\n" + "Перед созданием граней создайте хотя бы 2 вершины графа.", "",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                    break;
                case "path":
                    i = 0;
                    if (grph.Nodes.Count > 1)
                    {
                        do
                        {
                            p = grph.Nodes[i];
                            i++;
                            if (check_point(p.pnt, pnt.pnt)) pnt = p;
                        } while (pnt != p && i < grph.Nodes.Count);
                        if (p == pnt)
                            if (start_end.p1 == pnt.pnt || start_end.p2 == pnt.pnt)
                            {
                                if (start_end.p1 == pnt.pnt) start_end.p1 = new Point(0, 0);
                                else start_end.p2 = new Point(0, 0);
                            }
                            else
                                if (start_end.p1 == new Point(0, 0)) start_end.p1 = pnt.pnt;
                                else if (start_end.p2 == new Point(0, 0)) start_end.p2 = pnt.pnt;
                    }
                    else System.Windows.Forms.MessageBox.Show("Ошибка:\n" + "Перед этим действием нужно создать хотя бы 2 вершины.", "",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                    break;
            }
            print_graph(grph, cr_con, start_end, Canvas);
        }

        //Описываем действия для кнопок смены режимов
        private void Points_Click(object sender, EventArgs e)
        {
            start_end.p1 = new Point(0, 0);
            start_end.p2 = new Point(0, 0);
            string type = "point";
            if (Canvas.Tag as string == type)
            {
                Canvas.Tag = "";
                hint.Text = "Действие не выбрано.";
            }
            else
            {
                Canvas.Tag = type;
                hint.Text = "Клик по полю создает вершину, клик по созданной вершине убирает ее.";
            }
            print_graph(grph, cr_con, start_end, Canvas);
        }

        private void Lines_Click(object sender, EventArgs e)
        {
            start_end.p1 = new Point(0, 0);
            start_end.p2 = new Point(0, 0);
            string type = "line";
            if (Canvas.Tag == type)
            {
                Canvas.Tag = "";
                hint.Text = "Действие не выбрано.";
            }
            else
            {
                Canvas.Tag = type;
                hint.Text = "Для создания грани отметьте среди вершин ее начало и конец. Для удаления грани кликните по ее вершинам.";
            }
            print_graph(grph, cr_con, start_end, Canvas);
        }

        private void path_Click(object sender, EventArgs e)
        {
            start_end.p1 = new Point(0, 0);
            start_end.p2 = new Point(0, 0);
            string type = "path";
            if (Canvas.Tag == type)
            {
                Canvas.Tag = "";
                hint.Text = "Действие не выбрано.";
            }
            else
            {
                Canvas.Tag = type;
                hint.Text = "Отметьте вершины, между которыми нужно найти путь. Клик на отмеченной вершине отменит ее выбор.";
            }
            print_graph(grph, cr_con, start_end, Canvas);
        }

        //По нажатию кнопки найдем путь между отмеченными вершинами и выведем на экран
        private void calc_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Canvas.Image as Bitmap);
            Graphics _gr;
            if (bmp != null)
            {
                _gr = Graphics.FromImage(bmp);
                if (start_end.p1 != new Point(0, 0) && start_end.p2 != new Point(0, 0))
                {
                    List<Connection> lines = get_path(start_end, grph);
                    if (lines.Count > 0)
                        foreach (Connection l in lines) _gr.DrawLine(new Pen(Color.Red, 5), l.p1, l.p2);
                    else System.Windows.Forms.MessageBox.Show("Ошибка:\n" + "Не удалось найти ни одного пути между выбранными вершинами.", "",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else System.Windows.Forms.MessageBox.Show("Ошибка:\n" + "Пожалуйста, установите точки, между которыми нужно найти путь.", "",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                Canvas.Image = bmp;
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pref.Show();
        }

        private void сохранитьВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "graph-files (*.grp)|*.grp";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && sfd.FileName.Length > 0)
            {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream outputStream = File.OpenWrite(sfd.FileName);
            formatter.Serialize(outputStream, grph);
            outputStream.Close();
            }
        }

        private void загрузитьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "grph-files (*.grp)|*.grp";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK
                && ofd.FileName.Length > 0)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream inputStream = File.OpenRead(ofd.FileName);
                try
                {
                    grph = (Graph)formatter.Deserialize(inputStream);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка:\n" + ex.Message, "",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                inputStream.Close();
            }
            print_graph(grph, cr_con, start_end, Canvas);
        }

        //Добавление ноды по координатам
        private void add_point_Click(object sender, EventArgs e)
        {
            if (coord_x.Text != "" && coord_y.Text != "" && point_name.Text != "")
            {
                S_point pnt = new S_point(new Point(Convert.ToInt32(coord_x.Text), Convert.ToInt32(coord_y.Text)), 0, point_name.Text);
                S_point p = delete_exist_point(pnt.pnt, grph.Nodes);
                if (p == null)
                {
                    grph.Nodes.Add(pnt);
                    print_graph(grph, cr_con, start_end, Canvas);
                    coord_x.Text = "";
                    coord_y.Text = "";
                    point_name.Text = "";
                }
                else System.Windows.Forms.MessageBox.Show("Ошибка:\n" + "Уже существует вершина с такими координатами.", "",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
            else System.Windows.Forms.MessageBox.Show("Ошибка:\n" + "Должны быть указаны имя и координаты вершины.", "",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
        }

        //Разрешаем вводить только числа в поля для указания координат новой ноды
        private void coord_x_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void сохранитьВБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlConnection db_connection = new MySqlConnection(Con.get());
            try
            {
                db_connection.Open();
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка:\n" + ex.Message, "",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return;
            }
            //создаем таблицы, если их еще нет в выбраной базе, если есть - очищаем
            string query = "create table if not exists `points` (`id` int(11) not null auto_increment, `crd_x` int(11), `crd_y` int(11), `name` varchar(5), primary key (id)) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=0;";
            query += "create table if not exists `lines` (`id` int(11) not null, `cost` double) ENGINE=InnoDB  DEFAULT CHARSET=utf8;";
            query += "create table if not exists `lines_points` (`line_id` int(11) not null, `point_id` int(11) not null) ENGINE=InnoDB  DEFAULT CHARSET=utf8;";
            query += "delete from `lines_points`; delete from `lines`; delete from `points`;";
            MySqlCommand exec_query = new MySqlCommand(query, db_connection);
            exec_query.ExecuteNonQuery();

            //Передаем в БД вершины графа
            if (grph.Nodes.Count>0) {
            query = "insert into `points` (`crd_x`, `crd_y`, `name`) values ";
            foreach (S_point p in grph.Nodes)
                query += String.Format("({0}, {1}, '{2}'), ", p.pnt.X, p.pnt.Y, p.name);
            query = query.Substring(0, query.Length - 2);
            query += ";";
            exec_query = new MySqlCommand(query, db_connection);
            exec_query.ExecuteNonQuery();
            }
            if (grph.Lines.Count>0) {
            query = "insert into `lines` (`id`, `cost`) values ";
            i = 0;
            foreach (Connection c in grph.Lines)
            {
                query += String.Format("({0}, {1}), ", i, (c.cost + "").Replace(',', '.'));
                i++;
            }
            query = query.Substring(0, query.Length - 2);
            query += ";";
            exec_query = new MySqlCommand(query, db_connection);
            exec_query.ExecuteNonQuery();
            }
            //Передаем в БД ребра графа
            if (grph.Lines.Count>0) {
            query = "insert into `lines_points` (`line_id`, `point_id`) values ";
            i = 0;
            foreach (Connection c in grph.Lines)
            {
                query += String.Format("({0}, (select id from points where crd_x={1} and crd_y={2})), ", i, c.p1.X, c.p1.Y);
                query += String.Format("({0}, (select id from points where crd_x={1} and crd_y={2})), ", i, c.p2.X, c.p2.Y);
                i++;
            }
            query = query.Substring(0, query.Length - 2);
            query += ";";
            exec_query = new MySqlCommand(query, db_connection);
            exec_query.ExecuteNonQuery();
            }
            db_connection.Close(); 
        }

        private void загрузитьИзБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlConnection db_connection = new MySqlConnection(Con.get());
            try
            {
                db_connection.Open();
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка:\n" + ex.Message, "",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return;
            }
            //Загружаем из БД вершины графа
            MySqlDataReader reader;
            string query = "select * from `points`";
            MySqlCommand exec_query = new MySqlCommand(query, db_connection);
            try
            {
                reader = exec_query.ExecuteReader();
                while (reader.Read())
                {
                    grph.Nodes.Add(new S_point(new Point(reader.GetInt32(1),reader.GetInt32(2)),0,reader.GetString(3)));
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка:\n" + ex.Message, "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            //Загружаем из БД ребра графа
            query = "select lines.id,lines.cost,points.crd_x,points.crd_y from lines_points left join points on points.id=lines_points.point_id left join `lines` on lines.id=lines_points.line_id;";
            exec_query = new MySqlCommand(query, db_connection);
            try
            {
                reader = exec_query.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    if (reader.GetInt32(0)==grph.Lines.Count)
                     grph.Lines.Add(new Connection(new Point(reader.GetInt32(2), reader.GetInt32(3)), new Point(0, 0), reader.GetDouble(1)));
                    else grph.Lines[reader.GetInt32(0)].p2 = new Point(reader.GetInt32(2), reader.GetInt32(3));
                    i++;
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка:\n" + ex.Message, "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            db_connection.Close();
            print_graph(grph,cr_con,start_end,Canvas);
        }

    }
}
