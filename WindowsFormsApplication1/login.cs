using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public static Login pCurrentwin = null;
        //private bool n = false;

        public Login()
        {
            pCurrentwin = this;
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Verarbeitungen myVerarbeitungen = new Verarbeitungen();
            myVerarbeitungen.ShowHerbariumSheetsSinceTimeDialog();
        }
            
        

        //public TextBox username
        //{
        //    get { return this.username; }
        //}
    }
}
