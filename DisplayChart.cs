using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGU_Reporting_Tool
{
    public partial class DisplayChart : UserControl
    {
        private double _minValue;
        private double _maxValue;
        private double _currValue;
        private double _adjCurrValue;
        private const double expBase = 0.995;    // The closer this number to zero, the more exponential scaling occurs.

        public DisplayChart()
        {
            InitializeComponent();

            _minValue = _maxValue = _currValue = 0.0;
        }

        private void CalculateAdjustedValue()
        {
            if (_minValue != _maxValue)
            {
                try
                {
                    _adjCurrValue = _currValue * ((Math.Pow(expBase, -(_currValue - _minValue) / (_maxValue - _minValue)) - Math.Pow(expBase, -0)) / (Math.Pow(expBase, -1) - Math.Pow(expBase, -0)));
                }
                catch
                {
                    _adjCurrValue = 0.0;
                }
            }
            else
                _adjCurrValue = 0.0;
        }

        public double MinValue
        {
            get { return _minValue; }
            set
            {
                _minValue = value;
                this.CalculateAdjustedValue();
            }
        }

        public double MaxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                this.CalculateAdjustedValue();
            }
        }

        public double CurrentValue
        {
            get { return _maxValue; }
            set
            {
                _currValue = value;
                this.CalculateAdjustedValue();
            }
        }

        public double AdjustedCurrentValue
        {
            get { return _adjCurrValue; }
        }

        private void DisplayChart_Paint(object sender, PaintEventArgs e)
        {
            if (_minValue != _maxValue)
            {
                Graphics graphicsObj = this.CreateGraphics();

                // Determine x offset for current layout, in logarithmic scale
                double xTheta = (_adjCurrValue - _minValue) / (_maxValue - _minValue);

                // Draw filled portions
                Brush greenBrush = new SolidBrush(Color.Green);
                graphicsObj.FillRectangle(greenBrush, 0, 0, (float)(this.Width * xTheta), this.Height);
                Brush redBrush = new SolidBrush(Color.Red);
                graphicsObj.FillRectangle(redBrush, (float)(this.Width * xTheta), 0, (float)(this.Width * (1.0 - xTheta)), this.Height);

                // Draw black border
                Pen blackPen = new Pen(Color.Black, 2);
                graphicsObj.DrawRectangle(blackPen, 0, 0, this.Width, this.Height);
            }
        }
    }
}
