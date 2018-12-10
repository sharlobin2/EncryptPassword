using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace EncryptPassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string encrypt(string value)
        {
            using(MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
            {
                UTF8Encoding uft8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(uft8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter your password.","message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            txtResult.Text = encrypt(txtPassword.Text);
        }
    }
}
