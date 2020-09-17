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
using indice.Edi.Tests;
using indice.Edi.Tests.Models;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            var grammar = EdiGrammar.NewX12();
            string file = @"C:\Users\dell\Desktop\Stage\New Text Document2.txt";

            var x12_856 = new EdiSerializer().Deserialize<AdvanceShipNotice_856>(new StreamReader(file), grammar);

            //MessageBox.Show(x12_856.Groups[0].Orders[0].HierarchicalLevel1[0].Addresses[0].AddressCode);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
