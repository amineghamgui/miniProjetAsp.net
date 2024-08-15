using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using miniprojet.Models;

namespace miniprojet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Viewtest()
        {


            return View();
        }

  



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["cnxString"].ConnectionString;


        public List<marque0> GetDatabaseList()
        {
            List<marque0> list = new List<marque0>();
            DataTable obj = new DataTable();
            try
            {
                string query = string.Format(" select [marque] FROM [mini].[dbo].[mar]");
                SqlConnection connection = new SqlConnection(connectionString);
                {
                    connection.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
                    sqlData.Fill(obj);
                    foreach (DataRow row in obj.Rows)
                    {

                        list.Add(new marque0 { marque = row["marque"].ToString() });
                    }
                }


                return list;

            }
            catch (Exception ex)
            {
                return null;
            }


        }




        public List<selectvoitureadmin> adminlistvoiture()
        {
            List<selectvoitureadmin> list = new List<selectvoitureadmin>();
            DataTable obj = new DataTable();
            try
            {
                string query = string.Format(" select prix,marque,voiture from cars  order by(marque)");
                SqlConnection connection = new SqlConnection(connectionString);
                {
                    connection.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
                    sqlData.Fill(obj);
                    foreach (DataRow row in obj.Rows)
                    {

                        list.Add(new selectvoitureadmin { marque = row["marque"].ToString(), voiture = row["voiture"].ToString(), prix = Convert.ToInt32(row["prix"]) });
                    }
                }


                return list;

            }
            catch (Exception ex)
            {
                return null;
            }


        }




        public void insert(admininsert donne)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxString"].ConnectionString))
            {
                try
                {



                    SqlCommand command11 = new SqlCommand(String.Format("  insert into cars([photo1],[photo2],[photo3],[photo4],[photo5],[prix] ,[voiture],[marque]) values('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}')", donne.photo1, donne.photo2, donne.photo3, donne.photo4, donne.photo5, donne.prix, donne.voiture, donne.marque), connection);
                    command11.Connection.Open();
                    command11.ExecuteNonQuery();
                    command11.Connection.Close();


                    SqlCommand command2 = new SqlCommand(String.Format("  insert into dimensions([voiture],[d_longeur],[d_largeur],[d_hauteur]) values ('{0}',{1},{2},{3})", donne.voiture, donne.d_longeur, donne.d_largeur, donne.d_hauteur), connection);
                    command2.Connection.Open();
                    command2.ExecuteNonQuery();
                    command2.Connection.Close();


                    SqlCommand command3 = new SqlCommand(String.Format("    insert into caracteristiques([voiture],[c_nombre_place],[c_Grantie],[c_nbre_porte]) values('{0}',{1},{2},{3})", donne.voiture, donne.c_nombre_place, donne.c_Grantie, donne.c_nbre_porte), connection);
                    command3.Connection.Open();
                    command3.ExecuteNonQuery();
                    command3.Connection.Close();

                    SqlCommand command4 = new SqlCommand(String.Format("  insert into [motorisation]([voiture],[nbrecylindre],[energie],[puissance_fiscale] ,[puissance] ) values('{0}',{1},'{2}',{3},{4})    ", donne.voiture, donne.nbrecylindre, donne.energie, donne.puissance_fiscale, donne.puissance), connection);
                    command4.Connection.Open();
                    command4.ExecuteNonQuery();
                    command4.Connection.Close();


                    SqlCommand command5 = new SqlCommand(String.Format(" insert into options([voiture],[ecrant],[toit],[vitre],[demarrage],[climatisation])values('{0}', {1}, '{2}', '{3}', '{4}', '{5}')   ", donne.voiture, donne.ecrant, donne.toit, donne.vitre, donne.demarrage, donne.climatisation), connection);
                    command5.Connection.Open();
                    command5.ExecuteNonQuery();
                    command5.Connection.Close();

                    SqlCommand command6 = new SqlCommand(String.Format("   insert into  [performances] ([voiture],[p_0_100km],[p_vitessemax],[consomation]) values('{0}',{1},{2},{3}) ", donne.voiture, donne.p_0_100km, donne.p_vitessemax, donne.consomation), connection);
                    command6.Connection.Open();
                    command6.ExecuteNonQuery();
                    command6.Connection.Close();
                }
                catch (Exception ex)
                {

                }

            }

        }

        public void insertmarque(imarque im)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxString"].ConnectionString))
            {
                try
                {


                    SqlCommand command1 = new SqlCommand(String.Format("  insert into  [mar](marque,[photo_marque]) values('{0}','{1}')", im.marque, im.photo_marque), connection);
                    command1.Connection.Open();
                    command1.ExecuteNonQuery();
                    command1.Connection.Close();


                }
                catch (Exception ex)
                {

                }


            }
        }

        public void deletearticle(supprimearticle s)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxString"].ConnectionString))
            {
                try
                {


                    SqlCommand command1 = new SqlCommand(String.Format("   delete from cars where voiture ='{0}'", s.voiture), connection);
                    command1.Connection.Open();
                    command1.ExecuteNonQuery();
                    command1.Connection.Close();

                    SqlCommand command2 = new SqlCommand(String.Format("   delete from [dimensions] where voiture ='{0}'", s.voiture), connection);
                    command2.Connection.Open();
                    command2.ExecuteNonQuery();
                    command2.Connection.Close();

                    SqlCommand command3 = new SqlCommand(String.Format("   delete from [motorisation] where voiture ='{0}'", s.voiture), connection);
                    command3.Connection.Open();
                    command3.ExecuteNonQuery();
                    command3.Connection.Close();

                    SqlCommand command4 = new SqlCommand(String.Format("   delete from [options] where voiture ='{0}'", s.voiture), connection);
                    command4.Connection.Open();
                    command4.ExecuteNonQuery();
                    command4.Connection.Close();

                    SqlCommand command5 = new SqlCommand(String.Format("   delete from [performances] where voiture ='{0}'", s.voiture), connection);
                    command5.Connection.Open();
                    command5.ExecuteNonQuery();
                    command5.Connection.Close();

                }
                catch (Exception ex)
                {

                }


            }
        }




        public void updateprix(updateprice p)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxString"].ConnectionString))
            {
                try
                {


                    SqlCommand command1 = new SqlCommand(String.Format(" update  [cars] set prix={0} where voiture='{1}'", p.prix, p.voiture), connection);
                    command1.Connection.Open();
                    command1.ExecuteNonQuery();
                    command1.Connection.Close();


                }
                catch (Exception ex)
                {

                }
            }


        }



        public ActionResult View99()
        {
            List<selectvoitureadmin> list = new List<selectvoitureadmin>();
            list = adminlistvoiture();
            //selectvoitureadmins s= new selectvoitureadmins();
            //s.l = list;

            List<marque0> lg = new List<marque0>();
            lg = GetDatabaseList();
            // marques m = new marques();
            objectv obj = new objectv();
            obj.listmarques = lg;
            obj.lselectvoitureadmin = list;
            //m.listmarques = l;
            return View(obj);
        }
        //public ActionResult validTest(Login_ l)
        public bool validTest(Login_ l)
        {
            bool a = false;
            DataTable obj = new DataTable();

            try
            {
                string query = string.Format("SELECT TOP (1000) [login],[password]FROM[mini].[dbo].[usr]");
                SqlConnection connection = new SqlConnection(connectionString);
                {
                    connection.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
                    sqlData.Fill(obj);
                    foreach (DataRow row in obj.Rows)//for(int i = 0; i< conttacts.rows.lenght; i++)
                    {
                        //login.password = row["password"].ToString();
                        //login.login = row["login"].ToString();
                        if ((l.login == row["login"].ToString()) && (l.password == row["password"].ToString()))
                        {
                            a = true;

                            break;
                        }


                    }
                }



            }

            catch (Exception ex)
            {
                // return Content("Fail");
                //  return false;
            }

            //if (a == true)
            //    return Redirect("View99.cshtml");
            //else
            //    return Redirect("Viewtest.cshtml");


            return a;


        }



        //a*************************************************************************************************

        public List<affichmarque> utilisateurlistmarque()
        {
            List<affichmarque> list = new List<affichmarque>();
            DataTable obj = new DataTable();
            try
            {
                string query = string.Format(" select * from mar  order by(marque)");
                SqlConnection connection = new SqlConnection(connectionString);
                {
                    connection.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
                    sqlData.Fill(obj);
                    foreach (DataRow row in obj.Rows)
                    {

                        list.Add(new affichmarque
                        {
                            marque = row["marque"].ToString(),
                            photo_marque = row["photo_marque"].ToString()
                        });
                    }
                }


                return list;

            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public ActionResult Viewaffich()
        {
            listaffichmarques li = new listaffichmarques();
            li.lmarques = utilisateurlistmarque();


            return View(li);
        }



        //liste des photo des voiture
             static List<affichvoiture> listaa = new List<affichvoiture>();

        //public List<affichvoiture> getphotovoitures(getmarque m)
            public void getphotovoitures(getmarque m)
        {
            listaa = new List<affichvoiture>();
            admininsert a =new  admininsert();
            DataTable obj = new DataTable();
            //List<affichvoiture> listaa = new List<affichvoiture>();
            try
            {
                string query = string.Format(" exec Getvoitures22 @marque='{0}'", m.marque);
                SqlConnection connection = new SqlConnection(connectionString);
                {
                    connection.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
                    sqlData.Fill(obj);
                    foreach (DataRow row in obj.Rows)
                    {
                        listaa.Add(new affichvoiture { marque = row["marque"].ToString(), voiture = row["voiture"].ToString(), prix = Convert.ToInt32(row["prix"]) , photo1 = row["photo1"].ToString() });




                    }
                }


              // return listaa;

            }
            catch (Exception ex)
            {
              // return null;
            }




        }


 


        public ActionResult viewvoiture()
        {
            List<affichvoiture> laff = new List<affichvoiture>();

            //laff = getphotovoitures(m);



            listaffichvoitures listaffich = new listaffichvoitures();

            listaffich.laffichvoitures = listaa;





            return View(listaffich);
        }

        static List<admininsert> listbb=new List<admininsert>();
        public void listphotovoiturespeci(photospeciphique p)
        {
            listbb =new List<admininsert>();
            DataTable obj = new DataTable();
            //List<affichvoiture> listaa = new List<affichvoiture>();
            try
            {
                string query = string.Format(" exec Getvoituresp @voiture='{0}'", p.voiture);
                SqlConnection connection = new SqlConnection(connectionString);
                {
                    connection.Open();
                    SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
                    sqlData.Fill(obj);
                    foreach (DataRow row in obj.Rows)
                    {
                        listbb.Add(new admininsert
                        {
                            marque = row["marque"].ToString(),
                            climatisation = row["climatisation"].ToString(),
                            vitre = row["vitre"].ToString(),

                            voiture = row["voiture"].ToString(),
                            prix = Convert.ToInt32(row["prix"]),
                            photo1 = row["photo1"].ToString(),
                            photo2 = row["photo2"].ToString(),
                            photo3 = row["photo3"].ToString(),
                            photo4 = row["photo4"].ToString(),
                            photo5 = row["photo5"].ToString(),
                            puissance_fiscale = Convert.ToInt32(row["puissance_fiscale"]),
                            puissance = Convert.ToInt32(row["puissance"]),
                            p_0_100km = Convert.ToInt32(row["p_0_100km"]),
                            c_nbre_porte = Convert.ToInt32(row["c_nbre_porte"]),
                            consomation = Convert.ToInt32(row["consomation"]),
                            c_Grantie= Convert.ToInt32(row["c_Grantie"]),
                            c_nombre_place=Convert.ToInt32(row["c_nombre_place"]),
                            demarrage = row["demarrage"].ToString(),
                            toit = row["toit"].ToString(),
                            d_hauteur= Convert.ToInt32(row["d_hauteur"]),
                            d_largeur = Convert.ToInt32(row["d_largeur"]),
                            d_longeur= Convert.ToInt32(row["d_longeur"]),
                            ecrant= Convert.ToInt32(row["ecrant"]),
                            energie = row["energie"].ToString(),
                            nbrecylindre= Convert.ToInt32(row["nbrecylindre"]),
                            p_vitessemax = Convert.ToInt32(row["p_vitessemax"])



                        }) ;





                    }
                }


                

            }
            catch (Exception ex)
            {
                
            }



        }

        static List<commentaires> listcc = new List<commentaires>();
        public void  comment(insertcommentaires  p)
        {
            listcc = new List<commentaires>();
            DataTable obj = new DataTable();
            //List<affichvoiture> listaa = new List<affichvoiture>();
            try
            {
               
                    string query = string.Format(" Exec CreateCommentree '{0}','{1}' ", p.voiture, p.comm);
                    //string query = string.Format(" SELECT TOP (10) [voiture],[dateAjout],[commentaire] FROM [mini].[dbo].[com] where voiture='{0}' order by(dateAjout) desc ", p.voiture);
                    SqlConnection connection = new SqlConnection(connectionString);
                    {
                        connection.Open();
                        SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
                        sqlData.Fill(obj);
                        foreach (DataRow row in obj.Rows)
                        {
                        listcc.Add(new commentaires
                        {


                            voiture = row["voiture"].ToString(),
                            com = row["commentaire"].ToString(),
                            /*DateTime = row["dateAjout"].Equals(true) ? DateTime.Now : DateTime.Now*/
                            DateTime = DateTime.Parse(row["dateAjout"].ToString())



                            });





                        }
                        listcc.Reverse();
                    }

             


            }
            catch (Exception ex)
            {

            }



        }


        public void insertcomment(insertcommentaires v)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxString"].ConnectionString))
            {
                try
                {


                    SqlCommand command1 = new SqlCommand(String.Format("  insert into com(voiture,commentaire) values('{0}','{1}')", v.voiture, v.comm), connection);
                    command1.Connection.Open();
                    command1.ExecuteNonQuery();
                    command1.Connection.Close();


                }
                catch (Exception ex)
                {

                }


            }

        }





        public ActionResult Viewspeciphique()
        {
            //listcommentaires listcommentaires = new listcommentaires();
            //listcommentaires.commentaires = listcc;

            //listadminoo listadminoo = new listadminoo();
            //listadminoo.listadm = listbb;


            vispecifique v=new vispecifique();
            v.listadm = listbb;
            v.commentaires= listcc;

            ///listadmin.
            return View(v);
        }







    }

}

