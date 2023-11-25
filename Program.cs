using System.Security.Cryptography.X509Certificates;

namespace TetrisChallenge
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        public static void Main()
        {
            

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            FormEntrada formEntrada = new FormEntrada();

            // Exibe o FormEntrada usando Application.Run
            Application.Run(formEntrada);
            //ApplicationConfiguration.Initialize();
        }
    }
}