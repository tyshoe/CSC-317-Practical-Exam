using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC_317_Practical_Exam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //sets default image to gray
            imageTempGauge.Image = Properties.Resources.temperaturegauge_none;
        }

        private void numberboxTempValue_ValueChanged(object sender, EventArgs e)
        {
            //fahrenheit conversions
            decimal FTC_value = (numberboxTempValue.Value - 32M) * (5M / 9M);
            decimal FTK_value = (numberboxTempValue.Value - 32M) * (5M / 9M) + 273.15M;
            //celsius conversions
            decimal CTF_value = (numberboxTempValue.Value * (9M / 5M)) + 32;
            decimal CTK_value = numberboxTempValue.Value + 273.15M;
            //kelvin conversions
            decimal KTF_value = (numberboxTempValue.Value - 273.15M) * 9M / 5M + 32;
            decimal KTC_value = numberboxTempValue.Value - 273.15M;


            



            //changes values of label 1 and label 2 depending on value in combo box
            if (comboUnits.Text == "Fahrenheit")
            {
                lblConversion1Value.Text = String.Format("{0:F2}", FTC_value) + " Celsius";
                lblConversion2Value.Text = String.Format("{0:F2}", FTK_value) + " Kelvin";

                //prevents user from inputing Fahrenheit
                if (numberboxTempValue.Value < -459.67M)
                {
                    numberboxTempValue.Value = -459M;
                    ErrorMessageLabel.Text = "Errors: Fahrenheit cannot be less than -459.67°F, adjusted starting temperature to -459°F.";
                }
                else
                {
                    //sets error message to empty so it doesnt show
                    ErrorMessageLabel.Text = " ";
                }


                //based on raw value
                if (numberboxTempValue.Value > 95)//set image to red
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_hot;
                }
                else if (numberboxTempValue.Value > 75)//set image to yellow
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_warm;
                }
                else if (numberboxTempValue.Value > 55)//set image to green
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_mild;
                }
                else if (numberboxTempValue.Value > 33)//set image to blue
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_cold;
                }
                else if (numberboxTempValue.Value <= 33)//set image to purple
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_freezing;
                }

            }

            else if (comboUnits.Text == "Celsius")
            {
                lblConversion1Value.Text = String.Format("{0:F2}", CTF_value) + " Fahrenheit";
                lblConversion2Value.Text = String.Format("{0:F2}", CTK_value) + " Kelvin";

                //prevents user from inputing celsius
                if (numberboxTempValue.Value < -273.15M)
                {
                    numberboxTempValue.Value = -273.15M;
                    ErrorMessageLabel.Text = "Errors: Celsius cannot be less than -273.15°C, adjusted starting temperature to -273°C.";
                }
                else
                {
                    //sets error message to empty so it doesnt show
                    ErrorMessageLabel.Text = " ";
                }


                //based on a calculated value. not raw
                if (CTF_value > 95)//set image to red
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_hot;
                }
                else if (CTF_value > 75)//set image to yellow
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_warm;
                }
                else if (CTF_value > 55)//set image to green
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_mild;
                }
                else if (CTF_value > 33)//set image to blue
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_cold;
                }
                else if (CTF_value <= 33)//set image to purple
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_freezing;
                }
            }

            else if (comboUnits.Text == "Kelvin")
            {
                lblConversion1Value.Text = String.Format("{0:F2}", KTF_value) + " Fahrenheit";
                lblConversion2Value.Text = String.Format("{0:F2}", KTC_value) + " Celsius";

                //prevents user from inputing negative kelvin
                if (numberboxTempValue.Value < 0)
                {
                    numberboxTempValue.Value = 0;
                    ErrorMessageLabel.Text = "Errors: Kelvin cannot be less than 0K, adjusted starting temperature to 0K.";
                }
                else
                {
                    //sets error message to empty so it doesnt show
                    ErrorMessageLabel.Text = " ";
                }

                //based on a calculated value. not raw
                if (KTF_value > 95)//set image to red
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_hot;
                }
                else if (KTF_value > 75)//set image to yellow
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_warm;
                }
                else if (KTF_value > 55)//set image to green
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_mild;
                }
                else if (KTF_value > 33)//set image to blue
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_cold;
                }
                else if (KTF_value <= 33)//set image to purple
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_freezing;
                }
            }

        }


        //this section is essentially a copy and paste... although its not asked for, it didnt make sense to me that the program only updated if the value changes.
        //so i added this section which will also update the entire program if the value changes of the unit.
        private void comboUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fahrenheit conversions
            decimal FTC_value = (numberboxTempValue.Value - 32M) * (5M / 9M);
            decimal FTK_value = (numberboxTempValue.Value - 32M) * (5M / 9M) + 273.15M;
            //celsius conversions
            decimal CTF_value = (numberboxTempValue.Value * (9M / 5M)) + 32;
            decimal CTK_value = numberboxTempValue.Value + 273.15M;
            //kelvin conversions
            decimal KTF_value = (numberboxTempValue.Value - 273.15M) * 9M / 5M + 32;
            decimal KTC_value = numberboxTempValue.Value - 273.15M;






            //changes values of label 1 and label 2 depending on value in combo box
            if (comboUnits.Text == "Fahrenheit")
            {
                lblConversion1Value.Text = String.Format("{0:F2}", FTC_value) + " Celsius";
                lblConversion2Value.Text = String.Format("{0:F2}", FTK_value) + " Kelvin";

                //prevents user from inputing Fahrenheit
                if (numberboxTempValue.Value < -459.67M)
                {
                    numberboxTempValue.Value = -459M;
                    ErrorMessageLabel.Text = "Errors: Fahrenheit cannot be less than -459.67°F, adjusted starting temperature to -459°F.";
                }
                else
                {
                    //sets error message to empty so it doesnt show
                    ErrorMessageLabel.Text = " ";
                }


                //based on raw value
                if (numberboxTempValue.Value > 95)//set image to red
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_hot;
                }
                else if (numberboxTempValue.Value > 75)//set image to yellow
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_warm;
                }
                else if (numberboxTempValue.Value > 55)//set image to green
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_mild;
                }
                else if (numberboxTempValue.Value > 33)//set image to blue
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_cold;
                }
                else if (numberboxTempValue.Value <= 33)//set image to purple
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_freezing;
                }

            }

            else if (comboUnits.Text == "Celsius")
            {
                lblConversion1Value.Text = String.Format("{0:F2}", CTF_value) + " Fahrenheit";
                lblConversion2Value.Text = String.Format("{0:F2}", CTK_value) + " Kelvin";

                //prevents user from inputing celsius
                if (numberboxTempValue.Value < -273.15M)
                {
                    numberboxTempValue.Value = -273.15M;
                    ErrorMessageLabel.Text = "Errors: Celsius cannot be less than -273.15°C, adjusted starting temperature to -273°C.";
                }
                else
                {
                    //sets error message to empty so it doesnt show
                    ErrorMessageLabel.Text = " ";
                }


                //based on a calculated value. not raw
                if (CTF_value > 95)//set image to red
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_hot;
                }
                else if (CTF_value > 75)//set image to yellow
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_warm;
                }
                else if (CTF_value > 55)//set image to green
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_mild;
                }
                else if (CTF_value > 33)//set image to blue
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_cold;
                }
                else if (CTF_value <= 33)//set image to purple
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_freezing;
                }
            }

            else if (comboUnits.Text == "Kelvin")
            {
                lblConversion1Value.Text = String.Format("{0:F2}", KTF_value) + " Fahrenheit";
                lblConversion2Value.Text = String.Format("{0:F2}", KTC_value) + " Celsius";

                //prevents user from inputing negative kelvin
                if (numberboxTempValue.Value < 0)
                {
                    numberboxTempValue.Value = 0;
                    ErrorMessageLabel.Text = "Errors: Kelvin cannot be less than 0K, adjusted starting temperature to 0K.";
                }
                else
                {
                    //sets error message to empty so it doesnt show
                    ErrorMessageLabel.Text = " ";
                }

                //based on a calculated value. not raw
                if (KTF_value > 95)//set image to red
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_hot;
                }
                else if (KTF_value > 75)//set image to yellow
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_warm;
                }
                else if (KTF_value > 55)//set image to green
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_mild;
                }
                else if (KTF_value > 33)//set image to blue
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_cold;
                }
                else if (KTF_value <= 33)//set image to purple
                {
                    imageTempGauge.Image = Properties.Resources.temperaturegauge_freezing;
                }
            }
        }
    }
}
