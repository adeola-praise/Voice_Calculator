using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Speech.Recognition.SrgsGrammar;
using System.Globalization;

namespace Voice_Calculator
{
    public partial class OutputPage : Form
    {
        // Initialize a new instance of the SpeechSynthesizer to provide access to the functionality to the installed speech synthesis engine.
        SpeechSynthesizer ss = new SpeechSynthesizer();

        // Initialize a new instance of the PromptBuilder to add a variety of content types
        PromptBuilder pb = new PromptBuilder();

        // Initialize the speech recognizer.
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();

        // Initialize the variables for the two operands
        int firstOperand;
        int secondOperand;

        // Method for form designer support
        // Should not be modified
        public OutputPage()
        {
            InitializeComponent();
        }

        private void OutputPage_Load(object sender, EventArgs e)
        {
            // Sets the background color of the form
            this.BackColor = Color.FromArgb(100, 149, 237);
        }
        
        // Method for the start button
        private void Startbtn_Click(object sender, EventArgs e)
        {
            // Disable the start button and enable the stop button while the app is running
            Startbtn.Enabled = false;
            Stopbtn.Enabled = true;

            // Initialize a new srgsdoc for the minus operator xml file
            SrgsDocument srgsdoc = new SrgsDocument(@"c:\Users\hp\Documents\minusCommands.xml");

            // Initialize a new srgsdoc for the multiply operator xml file
            SrgsDocument srgsdoc_1 = new SrgsDocument(@"c:\Users\hp\Documents\multiplyCommands.xml");

            // Initialize a new srgsdoc for the addition operator xml file
            SrgsDocument srgsdoc_2 = new SrgsDocument(@"c:\Users\hp\Documents\additionCommands.xml");

            // Initialize a new srgsdoc for the division operator xml file
            SrgsDocument srgsdoc_3 = new SrgsDocument(@"c:\Users\hp\Documents\divisionCommands.xml");

            // Initialize a new grammar for the minus operator xml file
            Grammar minusGrammar = new Grammar(srgsdoc);

            // Initialize a new grammar for the multiply operator xml file
            Grammar multiplyGrammar = new Grammar(srgsdoc_1);

            // Initialize a new grammar for the minus operator xml file
            Grammar additionGrammar = new Grammar(srgsdoc_2);

            // Initialize a new grammar for the multiply operator xml file
            Grammar divisionGrammar = new Grammar(srgsdoc_3);

            try
            {
                // Request recognizer to pause to change its state
                sre.RequestRecognizerUpdate();

                // Initialize a handler for the SpeechRecognized event. 
                sre.SpeechRecognized += sre_SpeechRecognized;

                // Load multiply operation grammar
                sre.LoadGrammar(multiplyGrammar);

                // Load addition operation grammar
                sre.LoadGrammar(additionGrammar);

                // Load subtraction operation grammar
                sre.LoadGrammar(minusGrammar);

                // Load division operation grammar
                sre.LoadGrammar(divisionGrammar);

                // Configure the audio output
                sre.SetInputToDefaultAudioDevice();

                // Start asynchronous, ensures continuous speech recognition. 
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Sre_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            throw new NotImplementedException();
        }

        // Method for recognizing input and displaying results
        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // Store the user input in a string variable
            string inputVoice = e.Result.Text.ToString();
            
            // Identify a separator for the input
            string[] separator = {" "};

            // Split the input
            string[] strlist = inputVoice.Split(separator,
               StringSplitOptions.RemoveEmptyEntries);


            // Converts the operands from string to integer and returns the integer value
            bool firstParsable = int.TryParse(strlist[0], out firstOperand);
            bool secondParsable = int.TryParse(strlist[2], out secondOperand);

            if(firstParsable && secondParsable)
            {
                switch (strlist[1])
                {
                    // Addition operation
                    case "plus":
                        int sum = firstOperand + secondOperand;
                        ss.SpeakAsync(inputVoice + "=" + sum);
                        OutputBox.Text += firstOperand + "+" + secondOperand + "=" + sum + Environment.NewLine;
                        break;

                    // Subtraction operation
                    case "minus":
                        int subtract = firstOperand - secondOperand;
                        ss.SpeakAsync(inputVoice + "=" + subtract);
                        OutputBox.Text += firstOperand + "-" + secondOperand + "=" + subtract + Environment.NewLine;
                        break;

                    // Division operation
                    case "over":
                        int divide = firstOperand / secondOperand;
                        ss.SpeakAsync(inputVoice + "=" + divide);
                        OutputBox.Text += firstOperand + "/" + secondOperand + "=" + divide + Environment.NewLine;
                        break;

                    // Multiplication operation
                    case "times":
                        int multiply = firstOperand * secondOperand;
                        ss.SpeakAsync(inputVoice + "=" + multiply);
                        OutputBox.Text += firstOperand + "*" + secondOperand + "=" + multiply + Environment.NewLine;
                        break;
                }
            }
            
        }

        // Method for the stop button
        private void Stopbtn_Click(object sender, EventArgs e)
        {
            sre.RecognizeAsyncStop();
            Startbtn.Enabled = true;
            Stopbtn.Enabled = false;
        }

    }
}
