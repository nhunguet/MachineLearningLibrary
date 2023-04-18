using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningLibrary
{
    class NaiveBayes
    {


        
        public double ProbDensFunc(double u, double v, double x)
        
        {

            double left = 1.0 / Math.Sqrt(2 * Math.PI * v);
            double right = Math.Exp(-(x - u) * (x - u) / (2 * v));
            return left * right;
        
        }

    }
}
