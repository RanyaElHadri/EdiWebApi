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
using indice.Edi;

namespace WindowsFormsAppTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            var grammar = EdiGrammar.NewX12();

            string file = @"C:\Users\dell\Desktop\Stage\New Text Document.txt";
            var x12_850  = new EdiSerializer().Deserialize<PurchaseOrder_850>(new StreamReader(file), grammar);

            MessageBox.Show(x12_850.Date.ToString());
        }
    }
}
