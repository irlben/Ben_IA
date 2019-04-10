using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.ServiceProcess;
using Newtonsoft.Json;
using System.Net;

namespace BCA_MakingAnIA
{


    public partial class FrmPrincipal : Form
    {
        #region Description des objets
        SpeechSynthesizer s = new SpeechSynthesizer();
        
        Boolean wake = false;
        Choices list = new Choices();
        //ServiceController service = new ServiceController("SQL Server (MSSQLSERVER)", Environment.MachineName);
        const string APPID = "14c4be5ed015bf3b8fb3886a0dcb724d";
        //string cityID = "2982652"; 
        #endregion
        
        public static void StartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch
            {
                // ...
            }
        }
        public FrmPrincipal()
        {
            
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(File.ReadAllLines(@"C:\Users\Proprietaire\Documents\Projet_Perso\PROJET\BCA_MakingAnIA\BCA_MakingAnIA\Commands\Commands.txt"));


            

            Grammar gr = new Grammar(new GrammarBuilder(list));
           

            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeachRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            } catch (Exception)
            {
                MessageBox.Show("Erreur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            s.SelectVoiceByHints(VoiceGender.Neutral);
            s.Speak("Attendez quelques secondes, ça arrive");
            
            InitializeComponent();
        }


        public void restart()
        {
            Process.Start(@"C:\Users\Proprietaire\Documents\Projet_Perso\PROJET\BCA_MakingAnIA\BCA_MakingAnIA\bin\Debug\BCA_MakingAnIA.exe");
            Application.Exit();
        }
        public void end(String pR)
        {
            TxtInput.AppendText(pR + "\n");
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

            wplayer.URL = @"C:\Users\Proprietaire\Documents\Projet_Perso\PROJET\BCA_MakingAnIA\BCA_MakingAnIA\Commands\NonOrdinateur.mp3";
            wplayer.controls.play();
            wake = false;
        }
        public void search(String r)
        {
            if (r == "Recherche")
            {
                if (wake == true)
                {
                    Process.Start("https://www.google.fr/search?source=hp&ei=3bt7XO-KBamCjLsPgvusiAc&q=" + r);
                }
            }
        }
        public void say(String h)
        {
            s.Speak(h);
            TxtOutput.AppendText(h + "\n");
        }
        void getWeather(string city)
        {
            using (WebClient web = new WebClient())
            {

                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}&units=metric", city, APPID);

                var json = web.DownloadString(url);
            
                var result = JsonConvert.DeserializeObject<weatherInfo.root>(json);

               
                weatherInfo.root output = result;
                
                say("Il fait actuellement "+ string.Format("{0} \u00B0" + "C", output.main.temp));
                say("a" + string.Format("{0}", output.name));
                          
               
            }
        }
        int[] rdmnumber = new int[13] { 1,2,3,4,5,6,7,8,9,10,11,12,13 };
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
                say(myJoke.q_blagues);
                say(myJoke.r_blagues);
            }
            catch (Exception)
            {

                say("Je ne peux pas faire cela, une erreur s'est produite");
            }
            
        }
      


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
        #region Naturalisation des réponses
        String[] humeur = new string[3] { "Eh bien moi ça va et toi ?", "La forme et vous ?", "J'ai la patate aujourd'hui" };
        String[] faire_action = new string[4] { "Très bien", "Voici ce que vous m'avez demander", "Action effectué", "Et voici" };
        String[] chillmusic = new string[5] { "https://www.youtube.com/watch?v=EnHkibxvdfU", "https://www.youtube.com/watch?v=CuMPAkd5ZvI&t", "https://www.youtube.com/watch?v=Xyj0Mq-YdUY", "https://www.youtube.com/watch?v=A7Wo0MnC4z8", "https://www.youtube.com/watch?v=acibVFWo0UA" };

        public String chillmusic_action()
        {
            Random r = new Random();
            return chillmusic[r.Next(5)];
        }
        public String fairerep_action()
        {
            Random r = new Random();
            return faire_action[r.Next(4)];
        }
        public String humeur_action()
        {
            Random r = new Random();
            return humeur[r.Next(3)];
        }
        #endregion


        // COMMANDS

        public void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;
            String m = e.Result.Text;
            

            
            if (r == "Recherche")
            {
                Process.Start("https://www.google.fr/search?source=hp&ei=VseIXMGdAv3Igwe44r3IDg&q=" + m);
            }
            
            
            
            #region TEST, appel pour ouvrir discussion 
            if (r == "Ordinateur" || r == "nateur" || r == "Ordi")
            {
                
                wake = true;
                BtnRec.BackColor = Color.Green;
                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

                wplayer.URL = @"C:\Users\Proprietaire\Documents\Projet_Perso\PROJET\BCA_MakingAnIA\BCA_MakingAnIA\Commands\Ordinateur.mp3";
                wplayer.controls.play();
            }
            else
            {
                BtnRec.BackColor = Color.Red;
            }
            #endregion
            if (wake)
            {
                if (r == "Recherche")
                {
                    search(r);
                }
                // Redémarrage de l'appareil
                if (r == "Redemarre")
                {
                    restart();
                }
                #region Arret de l'appareil
                if (r == "Va dormir" || r == "Ferme toi")
                {
                    wake = false;
                    Application.Exit();
                }

                #endregion
                // Salutations
                if (r == "Salut" || r == "Bonjour" || r == "Hey")
                 {
                say("Salut"+Environment.MachineName);
                end(r);
                }
                 // Envoi de l'heure
                 if (r == "Quelle heure est-il?" || r == "Il est quel heure ?" || r == "L'heure s'il te plait")
                 {
                    say("Il est " + DateTime.Now.ToString("h:mm"));
                    end(r);
                  }
                 // Envoi de la date
                 if (r == "Quel jour sommes nous" || r == "C'est quel jour" || r == "Il est quel jour")
                  {
                   say("Nous sommes le " + DateTime.Now.ToString("dddd, dd MMMM yyyy"));
                 end(r);

                   }
             // Mise à jour
                if (r == "Met toi à jour")
                  {
                    say("Aucune mise à jour n'est encore disponible");
                    end(r);
                  }
             // Humeur
                 if (r == "Comment sa va" || r == "Comment va tu" || r == "Quel est ton humeur aujourdhui")
                {
                    say(humeur_action());
                    end(r);
                }
            // Youtube
                if (r == "Allons voir une video" || r == "Va sur Youtube" || r == "Ouvre YouTube" || r == "YouTube")
                {
                    say(fairerep_action());
                    OpenAppli("https://www.youtube.com");
                    end(r);
                }
                // Netflix
                if (r == "Allons voir des séries" || r == "Va sur Netflix" || r == "Ouvre Netflix" || r == "Netflix" )
                {
                    say(fairerep_action());
                    OpenAppli("https://www.netflix.com");
                    end(r);
                }
                // Navigateur par défaut
                 if (r == "Ouvre un navigateur" || r == "Ouvre Opera" || r == "Va sur Internet")
                 {
                say(fairerep_action());
                OpenAppli("https://google.fr");
                    end(r);
                }
            // Twitter
                if (r == "Ouvre Twitter" || r == "Va sur Twitter" || r == "Twitter")
                {
                    OpenAppli("https://Twitter.com");
                    end(r);
                }
                if (r == "Allons voir des memes")
                {
                    say(fairerep_action());
                    OpenAppli("https://twitter.com/irlbxn/lists/meme");
                    end(r);
                }
                
                // Lancement random d'une musique tranquille
                if (r == "Musique Tranquille")
                {
                    say(fairerep_action());
                    OpenAppli(chillmusic_action());
                    end(r);
                }
                // Fermer Opera
                if (r == "Ferme Opera")
                {
                    say(fairerep_action());
                    CloseAppli("opera");
                    end(r);
                }
                // Fermer Google Chrome
                if (r == "Ferme Google Chrome")
                {
                    say(fairerep_action());
                    CloseAppli("chrome");
                    end(r);
                }
                if (r == "Ouvre le terminal")
                {
                    say(fairerep_action());
                    OpenAppli(@"C:\WINDOWS\system32\cmd.exe");
                    end(r);
                }
                if (r == "Ferme le terminal")
                {
                    say(fairerep_action());
                    CloseAppli("cmd");
                    end(r);
                }
                // Ouvrir Google Chrome
                if (r == "Ouvre Google Chrome")
                {
                    say(fairerep_action());
                    OpenAppli(@"C:\Program Files (x86)\Google\Chrome\Application\Chrome.exe");
                    end(r);
                }

                if (r == "On se revoie bientôt")
                {
                    say("D'accord");
                    end(r);
                }
                if (r == "Calculatrice" || r == "Calculette" || r == "Ouvre la Calculatrice")
                {
                    OpenAppli("calc.exe");
                    end(r);
                }
                if (r == "Ferme Calculatrice")
                {
                    say(fairerep_action());
                    CloseAppli("Calculator");
                    end(r);
                }
                if (r == "Met toi en Icone")
                {
                    say(fairerep_action());
                    this.WindowState = FormWindowState.Minimized;
                    end(r);
                }
                if (r == "Met toi en Normal" || r == "Ouvre toi")
                {
                    say(fairerep_action());
                    this.WindowState = FormWindowState.Normal;
                    end(r);
                }
                if (r == "Met toi en Grand")
                {
                    say(fairerep_action());
                    this.WindowState = FormWindowState.Maximized;
                    end(r);
                }

                if (r == "Demarre les services SQL")
                {
                    say(fairerep_action());
                    StartService("SQL Server(MSSQLSERVER)", 300);         
                    end(r);
                }
                if (r == "Quel temps fait il")
                {
                    getWeather("2982652");
                    end(r);
                }
                if (r == "J'ai besoin d'un mot de passe")
                {
                    wake = false;
                   // mdp();
                }
                if (r == "Raconte moi une blague")
                {
                    GetBlagues();
                    end(r);
                }
                if (r == "Ferme la console")
                {
                    FrmConsole.ActiveForm.Close();
                    end(r);
                }
                if (r == "Que puis-je faire ?")
                {
                    say("Vous pouvez me demander d'ouvrir une application tel que Google Chrome");
                    say("Ou bien de me demander l'heure");
                    say("Ou bien l'heure ou la méteo");
                    say("La console peut vous aider a savoir ce que vous pouvez me demander avec le commande application.what");
                    end(r);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnRec.BackColor = Color.Red;
        }

        private void BtnRec_Click(object sender, EventArgs e)
        {
            wake = true;
            BtnRec.BackColor = Color.Green;
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

            wplayer.URL = @"C:\Users\Proprietaire\Documents\Projet_Perso\PROJET\BCA_MakingAnIA\BCA_MakingAnIA\Commands\Ordinateur.mp3";
            wplayer.controls.play();
        }
        public void mdp(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;
            do
            {
                say("Voulez vous l'enregistrer");
                if (r == "Oui")
                {

                }
                else
                {
                }
                    say("Voulez vous continuer à générer un mot de passe ? Si non, veuillez dire 'Stopper le processus'");
                
            } while (r == "Stopper le processus");
        }

        private void BtnModeConsole_Click(object sender, EventArgs e)
        {
            Form FrmConsole = new FrmConsole();
            FrmConsole.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
