using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCA_MakingAnIA
{
    class GetBlagues
    {
        public class blagues
        {
            public string id { get; set; } // Récupération de l'ID
            public string q_blagues { get; set; } // Récupération de la 'Question'
            public string r_blagues { get; set; } // Récupération de la 'Réponse' souvent appelé chute
            public string categ { get; set; } // Catégorie de la blague
        }
    }
}
