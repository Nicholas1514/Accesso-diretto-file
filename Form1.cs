using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accesso_diretto_file
{
    public partial class Form1 : Form
    {
        string nfile;
        public Form1()
        {
            InitializeComponent();
            nfile = @"crud.txt";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Creafile(textBox1.Text, textBox2.Text);
        }

        public void Creafile(string nprod, string prezzo)
        {
            if (!File.Exists(nfile))
            {
                using (StreamWriter sw = new StreamWriter(nfile, append: false))
                {
                    sw.WriteLine(nprod + " " + prezzo + " €");
                }
               
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(nfile, append: true))
                {
                    sw.WriteLine(nprod + " " + prezzo + " €");
                }
                   
            }
        }

        public void Cancellazione(string a)
        {
            using(StreamReader sr = File.OpenText(nfile))
            {
                string x;
                using(StreamWriter temp = new StreamWriter("temporaneo.txt"))
                {
                    while((x = sr.ReadLine()) != null)
                    {
 
                        if(x.Contains(a) == false)
                        {
                            temp.WriteLine(x);
                        }
                    }
                }
            }
            File.Delete(nfile);
            File.Move("temporaneo.txt", nfile);

        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancellazione(textBox3.Text);
        }
    }
}
