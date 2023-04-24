using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MachineLearningLib;

namespace TestApp
{
    public partial class Form1 : Form
    {

        NaiveBayes ml_naivebaye = null;
        public Form1()
        {
            InitializeComponent();

            ml_naivebaye = new NaiveBayes();
        }

        /// <summary>
        /// Initalization button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)

        {
            ml_naivebaye.Initialization();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ml_naivebaye.Setting();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ml_naivebaye.Training();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ml_naivebaye.Predict();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ml_naivebaye.SaveModel();
        }

        private void button6_Click(object sender, EventArgs e)
        
        {
            ml_naivebaye.LoadModel();
        }
    }
}
