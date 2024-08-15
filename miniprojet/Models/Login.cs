using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniprojet.Models
{

    public class insertcommentaires
    {
        public string voiture { get; set; }
        public string comm { get; set; }
        
    }
    public class commentaires
    {
        public string voiture { get; set; }
        public string com { get; set; }
        public DateTime DateTime { get; set; }
    }


    public class listcommentaires
    {
        public List<commentaires> commentaires { get; set; }
    }




    public class  vispecifique
    {
        public List<commentaires> commentaires { get; set; }
        public List<admininsert> listadm { get; set; }
    }

    public class photospeciphique
    {
        public string voiture { get; set; }
    }
    public class affichmarque
    {
        public string marque { get; set; }
        public string photo_marque { get; set; }
    }
    public class affichvoiture
    {
        public int prix { get; set; }
        public string voiture { get; set; }
        public string photo1 { get; set; }
        public string marque { get; set; }
    }


    public class listaffichvoitures
    {
        public List<affichvoiture> laffichvoitures { get; set; }
    }



    public class getmarque
    {
        public string marque { get; set; }
    }

    public class listaffichmarques
    { public List<affichmarque> lmarques { get; set; }

    }


    public class supprimearticle
    {

        public String voiture { get; set; }
    }


    public class Login_
    {
        public string login { get; set; }
        public string password { get; set; }
    }

    public class marque0
    {
        public string marque { get; set; }

    }
    public class marques
    {
        public List<marque0> listmarques { get; set; }
    }

    public class imarque
    {
        public string photo_marque { get; set; }
        public string marque { get; set; }
    }
    public class updateprice
    {

        public int prix { get; set; }
        public string voiture { get; set; }
    }
    public class selectvoitureadmin
    {
        public string marque { get; set; }
        public string voiture { get; set; }
        public int prix { get; set; }

    }
    public class selectvoitureadmins
    {
        public List<selectvoitureadmin> l { get; set; }
    }

    public class objectv
    {

        public List<selectvoitureadmin> lselectvoitureadmin { get; set; }
        public List<marque0> listmarques { get; set; }



    }
    public class deletev
    {

        public string marque { get; set; }
        public string voiture { get; set; }
    }


    public class deletevs
    {

        public List<deletev> listmarques { get; set; }
    }


    public class listadminoo{
        public List<admininsert> listadm { get; set; }
    }


public class admininsert
    {
        public int prix { get; set; }
        public string marque { get; set; }
        //public string photo_marque { get; set; }
        public string voiture { get; set; }

        public string photo1 { get; set; }
        public string photo2 { get; set; }
        public string photo3 { get; set; }
        public string photo4 { get; set; }

        public string photo5 { get; set; }





        public int d_longeur { get; set; }
        public int d_largeur { get; set; }
        public int d_hauteur { get; set; }




        public int c_nombre_place { get; set; }
        public int c_Grantie { get; set; }
        public int c_nbre_porte { get; set; }


        public int nbrecylindre { get; set; }
        public string energie { get; set; }

        public int puissance_fiscale { get; set; }

        public int puissance { get; set; }



        public float ecrant { get; set; }

        public string toit { get; set; }

        public string vitre { get; set; }
        public string demarrage { get; set; }
        public string climatisation { get; set; }




        public int p_0_100km { get; set; }
        public int p_vitessemax { get; set; }
        public int consomation { get; set; }


    }




}