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

namespace WindowsFormsApplication1
{
    public partial class prefs : Form
    {
        Form1 main;
        
        public prefs()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            main.Con.set_host(host.Text);
            main.Con.set_name(db_name.Text);
            main.Con.set_user(user.Text);
            main.Con.set_pass(pass.Text);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream outputStream = File.OpenWrite("prefs");
            formatter.Serialize(outputStream, main.Con);
            outputStream.Close();
        }

        private void prefs_FormClosing(object sender, FormClosingEventArgs e)
        {
            (sender as prefs).Hide();
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            e.Cancel = true;
        }

        private void prefs_Shown(object sender, EventArgs e)
        {
            main = (this.Owner as Form1);
            host.Text = main.Con.get_host();
            db_name.Text = main.Con.get_name();
            user.Text = main.Con.get_user();
            pass.Text = main.Con.get_pass();
        }
    }
}
