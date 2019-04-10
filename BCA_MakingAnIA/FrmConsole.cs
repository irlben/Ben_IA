using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCA_MakingAnIA
{
    public partial class FrmConsole : Form
    {
        public FrmConsole()
        {
            InitializeComponent();
            
        }
        const string APPID = "14c4be5ed015bf3b8fb3886a0dcb724d";
        void getWeather(string city)
        {
            using (WebClient web = new WebClient())
            {


                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}&units=metric", city, APPID);

                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<weatherInfo.root>(json);

                weatherInfo.root output = result;


                Lbl_Console.Text = (string.Format("{0} \u00B0" + "C", output.main.temp));

            }
        }
        public string version = "1.0";
        private bool command = false;
        private static void OpenAppli(string pName)
        {
            Process.Start(pName);

        }
        private static void CloseAppli(string pName)
        {
            foreach (var process in Process.GetProcessesByName(pName))
            {
                process.Kill();
            }
        }
        #region RdmChillMusic
        String[] chillmusic = new string[5] { "https://www.youtube.com/watch?v=EnHkibxvdfU", "https://www.youtube.com/watch?v=CuMPAkd5ZvI&t", "https://www.youtube.com/watch?v=Xyj0Mq-YdUY", "https://www.youtube.com/watch?v=A7Wo0MnC4z8", "https://www.youtube.com/watch?v=acibVFWo0UA" };

        public String chillmusic_action()
        {
            Random r = new Random();
            return chillmusic[r.Next(5)];
        } 
        #endregion
        public void commands()
        {
            if (command)
            {

            
            
            }
        }
        int[] rdmnumber = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        public int rdm()
        {
            Random r = new Random();
            return rdmnumber[r.Next(13)];
        }
        private void GetBlagues()
        {
            try
            {
                WebRequest request = HttpWebRequest.Create("https://bridge.buddyweb.fr/api/apiblagues/blagues/" + rdm());
                WebResponse reponse = request.GetResponse();
                StreamReader reader = new StreamReader(reponse.GetResponseStream());
                string Joke_JSON = reader.ReadToEnd();

                GetBlagues.blagues myJoke = JsonConvert.DeserializeObject<GetBlagues.blagues>(Joke_JSON);
                MessageBox.Show(myJoke.q_blagues, "[BLAGUE MANAGER]");
                MessageBox.Show(myJoke.r_blagues, "[BLAGUE MANAGER]");
                Lbl_Console.Text = "Vous avez éxécuté la commande pour recevoir une blague";
            }
            catch (Exception)
            {

                Lbl_Console.Text = ("Je ne peux pas faire cela, une erreur s'est produite");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (TxtConsole.Text == "help")
            {
                BtnClear.Visible = true;
                TxtConsole.Text = "";
                TxtConsole.Text = "change.txtcolor: [white:black:red:blue]"  + " \r\n" + " | Met le texte en couleur" + "\r\n" + "      " + "\r\n" + "      " + "\r\n" +
                                  "console.exit: " + "\r\n" + "| Quitte la console" + "\r\n" + "      " + "\r\n" + "      " +
                                  "Ordinateur.open" + "\r\n" + "| Se mettre en mode IA" + "\r\n" + "      " + "\r\n" + "      " +
                                  "Ordinateur.open" + "\r\n" + "| Se mettre en mode IA" + "\r\n" + "      " + "\r\n" + "      " +
                                  "Ordinateur.open" + "\r\n" + "| Se mettre en mode IA" + "\r\n" + "      " + "\r\n" + "      " +
                                  "Ordinateur.open" + "\r\n" + "| Se mettre en mode IA" + "\r\n" + "      " + "\r\n" + "      " +
                                  "Ordinateur.open" + "\r\n" + "| Se mettre en mode IA" + "\r\n" + "      " + "\r\n" + "      " +
                                  "Ordinateur.open" + "\r\n" + "| Se mettre en mode IA" + "\r\n" + "      " + "\r\n" + "      " +
                                  "Ordinateur.open" + "\r\n" + "| Se mettre en mode IA" + "\r\n" + "      " + "\r\n" + "      " +
                                  "Ordinateur.open" + "\r\n" + "| Se mettre en mode IA" + "\r\n" + "      " + "\r\n" + "      ";
                
            }
            #region Commands
            #region Change.txtcolor (color)
            if (TxtConsole.Text == "change.txtcolor white")
            {
                TxtConsole.ForeColor = System.Drawing.Color.White;
                Lbl_Console.Text = "Vous avez bien changer la couleur en blanc";
                TxtConsole.Text = "";
            }
            else
               if (TxtConsole.Text == "change.txtcolor black")
            {
                TxtConsole.ForeColor = System.Drawing.Color.Black;
                Lbl_Console.Text = "Vous avez bien changer la couleur en noir";
                TxtConsole.Text = "";
            }
            else
               if (TxtConsole.Text == "change.txtcolor blue")
            {
                TxtConsole.ForeColor = System.Drawing.Color.Blue;
                Lbl_Console.Text = "Vous avez bien changer la couleur en bleu";
                TxtConsole.Text = "";
            }
            else
               if (TxtConsole.Text == "change.txtcolor red")
            {
                TxtConsole.ForeColor = System.Drawing.Color.Red;
                Lbl_Console.Text = "Vous avez bien changer la couleur en rouge";
                TxtConsole.Text = "";
            }
            #endregion

            #region console.exit
            if (TxtConsole.Text == "console.exit")
            {
                this.Close();
                Lbl_Console.Text = "Vous avez quitter la console";
                TxtConsole.Text = "";
            }
            #endregion

            #region En mode IA
            if (TxtConsole.Text == "Ordinateur.open")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous êtes en mode IA";
                command = true;
                commands();

            }
            #endregion
            #region Salut
            if (TxtConsole.Text == "Salut" || TxtConsole.Text == "Bonjour" || TxtConsole.Text == "Hey")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Salut";
            }
            #endregion
            else
            #region Envoi l'heure
            // Envoi de l'heure
            if (TxtConsole.Text == "Quelle heure est-il?" || TxtConsole.Text == "Il est quel heure ?" || TxtConsole.Text == "L'heure s'il te plait" || TxtConsole.Text == "L'heure")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = ("Il est " + DateTime.Now.ToString("h:mm"));
            }
            #endregion
            else
            #region Envoi la date
            // Envoi de la date
            if (TxtConsole.Text == "Quel jour sommes nous" || TxtConsole.Text == "C'est quel jour" || TxtConsole.Text == "Il est quel jour")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = ("Nous sommes le " + DateTime.Now.ToString("dddd, dd MMMM yyyy"));

            }
            #endregion
            else
            #region Mise à jour
            // Mise à jour
            if (TxtConsole.Text == "Met toi à jour")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous êtes sur la version " + version;
                Lbl_Console.Text = ("Aucune mise à jour n'est encore disponible");
            }
            #endregion
            else
            #region Comment ça va 
            // Humeur
            if (TxtConsole.Text == "Comment sa va" || TxtConsole.Text == "Comment va tu" || TxtConsole.Text == "Quel est ton humeur aujourdhui")
            {
                TxtConsole.Text = "";
            }
            #endregion
            else
            #region Ouvrir Youtube
            // Youtube
            if (TxtConsole.Text == "Allons voir une vidéo" || TxtConsole.Text == "Va sur Youtube" || TxtConsole.Text == "Ouvre YouTube" || TxtConsole.Text == "YouTube")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous avez ouvert Youtube";
                OpenAppli("https://www.youtube.com");
            }
            #endregion
            else
            #region Ouvrir Netflix
            // Netflix
            if (TxtConsole.Text == "Allons voir des séries" || TxtConsole.Text == "Va sur Netflix" || TxtConsole.Text == "Ouvre Netflix" || TxtConsole.Text == "Netflix")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous avez ouvert Netflix";
                OpenAppli("https://www.netflix.com");
            }
            #endregion
            else
            #region Ouvrir Navigateur (par défaut)
            // Navigateur par défaut
            if (TxtConsole.Text == "Ouvre un navigateur" || TxtConsole.Text == "Ouvre Opera" || TxtConsole.Text == "Va sur Internet" || TxtConsole.Text == "ouvre Opera" || TxtConsole.Text == "ouvre opera" || TxtConsole.Text == "va sur Internet" || TxtConsole.Text == "va sur internet")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous avez ouvert Opera";
                OpenAppli("https://google.fr");
            }
            #endregion
            else
            #region Ouvrir Twitter
            // Twitter
            if (TxtConsole.Text == "Ouvre Twitter" || TxtConsole.Text == "Va sur Twitter" || TxtConsole.Text == "Twitter")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous avez ouvert Twitter";
                OpenAppli("https://Twitter.com");
            }
            #endregion
            else
            #region Ouvrir Liste meme
        if (TxtConsole.Text == "Allons voir des memes")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous avez ouvert twitter pour voir des memes";
                OpenAppli("https://twitter.com/irlbxn/lists/meme");
            }
            #endregion
            else

            #region Ouvrir Playlist random musique chill
            // Lancement random d'une musique tranquille
            if (TxtConsole.Text == "Musique Tranquille")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous avez lancé votre musique tranquille";
                OpenAppli(chillmusic_action());
            }
            #endregion
            else
            #region Fermer Opera
            // Fermer Opera
            if (TxtConsole.Text == "Ferme Opera")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous avez fermer Opera";
                CloseAppli("opera");
            }
            #endregion
            else
            #region Fermer Google Chrome
            // Fermer Google Chrome
            if (TxtConsole.Text == "Ferme Google Chrome")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous avez fermer Google Chrome";
                CloseAppli("chrome");
            }
            #endregion
            else
            #region Ouvrir Google Chrome
            // Ouvrir Google Chrome
            if (TxtConsole.Text == "Ouvre Google Chrome")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous avez ouvert Google Chrome";
                OpenAppli(@"C:\Program Files (x86)\Google\Chrome\Application\Chrome.exe");
            }
            #endregion
            else

            #region On se revoit bientot ?
            if (TxtConsole.Text == "On se revoie bientôt")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = ("D'accord");
            }
            #endregion
            else
            #region Ouvrir Calculatrice
            if (TxtConsole.Text == "Calculatrice" || TxtConsole.Text == "Calculette" || TxtConsole.Text == "Ouvre la Calculatrice" || TxtConsole.Text == "ouvre la Calculatrice" || TxtConsole.Text == "Ouvre la calculatrice" || TxtConsole.Text == "ouvre la calculatrice")
            {
                Lbl_Console.Text = "Vous avez ouvert la Calculatrice";
                TxtConsole.Text = "";
                OpenAppli("calc.exe");
            }
            #endregion
            else
            #region Fermer Calculatrice
             if (TxtConsole.Text == "Ferme Calculatrice" || TxtConsole.Text == "Ferme calculatrice" || TxtConsole.Text == "ferme Calculatrice" || TxtConsole.Text == "ferme calculatrice")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous avez fermer la Calculatrice";
                CloseAppli("Calculator");
            }
            #endregion
            else
            #region Mettre en icone
        if (TxtConsole.Text == "Met toi en Icone" || TxtConsole.Text == "Met toi en Icone" || TxtConsole.Text == "Met toi en icone" || TxtConsole.Text == "met toi en Icone" || TxtConsole.Text == "met toi en icone")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Votre application est en icone";
                this.WindowState = FormWindowState.Minimized;
            }
            #endregion
            else
            #region Mettre en Normal
        if (TxtConsole.Text == "Met toi en Normal" || TxtConsole.Text == "Ouvre toi")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Votre application est en Normal";
                this.WindowState = FormWindowState.Normal;
            }
            #endregion
            else
            #region Mettre en Grand
        if (TxtConsole.Text == "Met toi en Grand" || TxtConsole.Text == "met toi en Grand" || TxtConsole.Text == "met toi en grand " || TxtConsole.Text == "Met toi en grand" || TxtConsole.Text == "MET TOI EN GRAND")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Votre application est aggrandi";
                this.WindowState = FormWindowState.Maximized;
            }
            #endregion
            #region Afficher la temperature
            if (TxtConsole.Text == "Temperature" || TxtConsole.Text == "temperature")
            {
                TxtConsole.Text = "";
                getWeather("2982652");
            }
            #endregion
            if (TxtConsole.Text == "Une blague")
            {
                GetBlagues();
            }
            #region Ouvrir Atom
            if (TxtConsole.Text == "Ouvre Atom" || TxtConsole.Text == "ouvre Atom" || TxtConsole.Text == "ouvre atom" || TxtConsole.Text == "Ouvre atom")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous avez ouvert Atom";
                OpenAppli(@"C:\Users\Proprietaire\AppData\Local\atom\atom.exe");
            }
            #endregion
            #region Fermer Atom
            if (TxtConsole.Text == "Ferme Atom" || TxtConsole.Text == "ferme Atom" || TxtConsole.Text == "ferme atom" || TxtConsole.Text == "Ferme atom")
            {
                TxtConsole.Text = "";
                Lbl_Console.Text = "Vous avez fermer Atom";
                CloseAppli("Atom");
            }
            #endregion
            #region Tout fermer
            if (TxtConsole.Text == "application.exit")
            {
                TxtConsole.Text = "";
                this.Close();
                Application.Exit();
            }
            #endregion 
            #endregion


        }

        private void FrmConsole_Load(object sender, EventArgs e)
        {
            BtnClear.Visible = false;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtConsole.Text = "";
            Lbl_Console.Text = "Vous avez quitter le menu HELP";
            BtnClear.Visible = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

