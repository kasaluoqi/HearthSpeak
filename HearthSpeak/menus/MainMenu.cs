using System;
using System.Speech.Recognition;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthSpeak.menus
{
    class MainMenu : BaseMenu
    {
        double width;
        double height;
        public MainMenu(double width, double height)
        {
            this.width = width;
            this.height = height;
            Add("Start Listening", StartListening);
            //Add("Change Screen Resolution", AdjustResolution);
            Add("Quit", ExitApplication);
            Prompt = "Enter an option: ";
            Display();
            Console.ReadLine();
        }

        public void AdjustResolution()
        {
            
        }

        public void ExitApplication()
        {
            System.Environment.Exit(1);
        }

        public void StartListening()
        {
            var recognizer = new Recognizer(width, height);
            recognizer.ListenIO();
        }

    }
}
