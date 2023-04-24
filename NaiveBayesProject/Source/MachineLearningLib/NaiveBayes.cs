﻿////import library 
///

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MachineLearningLib
{
    public class NaiveBayes
   
    {

        #region Properties
        
       // private int num_class = 0;
        //private int num_features = 0;
        //private int num_samples = 0;
       // private double[,] data = null;
        
        #endregion

        #region Constructor / Destructor
        

        public NaiveBayes() 
        
        {
            
        }
        #endregion

        #region Initialization
        
        public void Initialization()
        
        {
            int num_class = 3;
            int num_features = 4;
            
            //data = new double[num_class, num_features];

            int N = 117;

            // Load Input Data
            
            string fn = "D:/Data/IrisDataTrainning.txt";
            
            
            /*int N_feature = 5;
            int N_class = 3;
            int N = 150;*/
            

            //return data;
            // Load data
            // num_samples = LoadData();
        }

        public double[][] LoadData(string fn, int rows, int cols, char delimit)

        {
            // Load data from file to data variable
            
            // data
            
            double[][] result = MatrixString(rows, cols);
            
            FileStream ifs = new FileStream(fn, FileMode.Open);
            StreamReader sr = new StreamReader(ifs);

            string[] tokens = null;
            string line = null; 
            int i = 0;

            while ((line = sr.ReadLine()) != null)
            {
                tokens = line.Split(delimit);
                for (int j = 0; j < cols; ++j)
                    result[i][j] = tokens[i][j];
                ++i;
            }
            sr.Close(); ifs.Close();
            return result;

         //   return data.Length;
        }


        /// <summary>
        /// Function 
        /// </summary>

        public double[][] MatrixString(int rows, int cols)
        {
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
        }
        #endregion

        #region Setting
        public void Setting()
        {
            // do setting 
        }
        #endregion

        #region Training
        public void Training()
        {
        
            double[][] data = LoadData(fn, N, num_features + 1, ',');
            // mean calculation
            var means = MeanCalculation(data);


            // varian calucatio
            var varians = VarianCalculation(data);


            //gause properties
            var gauges = GaugeCalculation(means, varians);


        }

        /// <summary>
        /// Mean calculation for data
        /// </summary>
        /// <param name="input_data"></param>
        /// <returns></returns>
        private double[,] MeanCalculation(double[,] input_data)
        {
            // 1. compute means 
            double[,] means = new double[1,1];  // [class][predictor]
            return means;

        }

        /// <summary>
        /// Calculate varian for data
        /// 
        /// 
        /// </summary>
        /// <param name="input_data"></param>
        /// <returns></returns>
        

        private double[,] VarianCalculation(double[,] input_data)

        
        {
            double[,] varians = new double[1, 1];

            return varians;
        }

        /// <summary>
        /// calculate gague for data
        /// </summary>
        /// 
        /// 
        /// <param name="means"></param>
        /// <param name="varians"></param>
        /// <returns></returns>
        private double[,] GaugeCalculation(double[,] means, double[,] varians)
        {
            double[,] gauges = new double[1, 1];

            return gauges;
        }
        #endregion

        #region Predict
        public void Predict()
        {
            //

            //


        }
        #endregion

        #region Save Model
        public void SaveModel()
        {
            // Serialize 

            // save to file

        }
        #endregion

        #region Load Model
        public void LoadModel()
        {
            // Read file

            // De-Serialize 

            // Create object
        }
        #endregion

    }
}
