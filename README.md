# Voice Calculator

Voice Calculator is an application that performs mathematical calculation by receiving input from speech and outputs the result in both speech and text format.<br>

## Description
- Unlike the conventional calculators in which users have to input mathematical problems by punching a bunch of keys, this application allows users to speak their mathematical problems. It then performs the necessary operations and returns the solution in speech and text format.<br>
- It is a Windows Forms application that utilizes the Windows Desktop Speech technology types to implement speech recognition. 
- It references a speech recognition grammar (a folder of XML documents authored by me) which defines the constraints for speech recognition. It defines what the speech recognition engine can recognize as meaningful input; therefore, any other grammar would not be recognized by the calculator.
- This application is completely written in the C# programming language.

## Things You Need to Know
- The application only works with the number range 0 - 99.
- It performs only four mathematical operations: Multiplication, Addition, Subtraction and Division.
- The following grammar are recognized for the mathematical operations: "plus", "adds", "minus", "times" and "divides".

## How it Works
- Click on the start button.
- Speak the mathematical problem to the calculator. For example: "forty plus ten"
- Once the start button is clicked, continuous speech recognition is activated therefore you don't have to click the start button again for another input.

## Visuals
Here's a Screenshot!:

![alt text](https://github.com/adeola-praise/Voice_Calculator/blob/master/Start.png "UI Screenshot")
