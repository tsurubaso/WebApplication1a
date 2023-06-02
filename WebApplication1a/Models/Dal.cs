using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace WebApplication1a.Models
{
    public class Dal
    {
        public Response Registration(Registration registration, SqlConnection connection) 
        
        {
        Response response = new Response();
        SqlCommand cmd = new SqlCommand("INSERT INTO Registration(Name, Email, Password, PhoneNo, IsActive, IsApproved) VALUES('"+registration.Name+"','"+registration.Email+"','"+registration.Password+"','"+registration.PhoneNo+"',1,0)", connection);
        connection.Open();
        int i=cmd.ExecuteNonQuery();
        connection.Close();
        if (i > 0)
            {
                response.StatusCode = 200; 
                response.StatusMessage = "Registration Successful";

            }
        else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Registration failed";


            }


            return response;
        
        
        }

        public Response Login(Registration registration, SqlConnection connection)

        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Registration WHERE Email='"+registration.Email+"'AND Password='"+registration.Password+"'", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                response.StatusCode=200;
                response.StatusMessage = "Login successful";
                Registration reg= new Registration();
                reg.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                reg.Name= Convert.ToString(dt.Rows[0]["Name"]);
                reg.Email = Convert.ToString(dt.Rows[0]["Email"]);
                response.Registration = reg;

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Login failed";
                response.Registration = null;



            }
            return response;


        }

        public Response UserApproval(Registration registration, SqlConnection connection) 
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE registration SET IsApproved = 1 WHERE Id='"+registration.Id+ "'AND IsActive=1 ", connection);
            connection.Open();
            int i=cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0) 
            {
                response.StatusCode = 200;
                response.StatusMessage = "User Approuved";

            }
            else
            {

                response.StatusCode = 100;
                response.StatusMessage = "User Not Approuved";
            }

            return response;

        }

        public Response AddNews(News news, SqlConnection connection)
        {


            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO News(Title,Content,Email,IsActive,CreatedOn) VALUES ('"+news.Title + "','"+ news.Content+ "','"+news.Email+"',1,GETDATE())", connection );
            connection.Open();
            int i=cmd.ExecuteNonQuery();
            connection.Close();
            if(i > 0) 
            {

                response.StatusCode = 200; 
                response.StatusMessage = "News Created";

            }
            else
            {

                response.StatusCode = 100;
                response.StatusMessage = "News Failed";
            }
            return response;

        }

        public Response NewsList(SqlConnection connection)
        
        {
        Response response= new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM News WHERE IsActive=1 ", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<News> lstNews = new List<News>(); 
            if(dt.Rows.Count > 0)
            { 
                for(int i=0; i<dt.Rows.Count;i++)
                {
                    News news = new News();
                    news.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    news.Title= Convert.ToString(dt.Rows[i]["Title"]);
                    news.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    news.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    news.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    news.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                    lstNews.Add(news);



                }
                if (lstNews.Count>0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "News data";  
                    response.listNews = lstNews;

                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No News data found";
                    response.listNews = null;


                }
               
            

            }
            else
            {

                response.StatusCode = 100;
                response.StatusMessage = "No News data found";
                response.listNews = null;


            }
            return response;

        }

        public Response AddArticle(Article article, SqlConnection connection)
        {


            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Article(Title,Content,Email,Image,IsActive,IsApproved) VALUES ('" + article.Title + "','" + article.Content + "','" + article.Email + "','" + article.Image + "',1,0)", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Article Created";

            }
            else
            {

                response.StatusCode = 100;
                response.StatusMessage = "Article Failed";
            }
            return response;

        }

        public Response ArticleList(Article article,SqlConnection connection) 

        {
            Response response = new Response();
            SqlDataAdapter da = null;
            if (article.type == "User")
            {
                new SqlDataAdapter("Select * FROM Article WHERE Email='" + article.Email + "'AND IsActive=1", connection);

            }
            if (article.type == "Page")
            {
                new SqlDataAdapter("Select * FROM News WHERE IsActive=1 ", connection);

            }
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Article> lstArticle = new List<Article>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Article art = new Article();
                    art.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    art.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    art.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    art.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    art.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    art.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    lstArticle.Add(art);



                }
                if (lstArticle.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Article data found";
                    response.listArticle = lstArticle;

                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No Article data found";
                    response.listNews = null;


                }


            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Article data found";
                response.listNews = null;

            }
           
            return response;

        }

        public Response ArticleApproval(Article article, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Article SET IsApproved = 1 WHERE Id='" + article.Id + "'AND IsActive=1 ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Article Successful";

            }
            else
            {

                response.StatusCode = 100;
                response.StatusMessage = "Article rejected";
            }

            return response;

        }

        public Response StaffRegistration(Staff staff, SqlConnection connection)

        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Staff(Name, Email, Password, IsActive) VALUES('" + staff.Name + "','" + staff.Email + "','" + staff.Password + "',1)", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Staff Registration Successful";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff Registration failed";


            }


            return response;


        }

        public Response DeleteRegistration(Staff staff, SqlConnection connection)

        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM Staff WHERE ID='" + staff.Id + "' AND IsActive=  1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Staff Deleted Successful";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Staff Deletion failed";


            }


            return response;


        }

        public Response AddEvent(Events events, SqlConnection connection)
        {


            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Events(Title,Content,Email,IsActive,CreatedOn) VALUES ('" + events.Title + "','" + events.Content + "','" + events.Email + "',1,GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "Event Created";

            }
            else
            {

                response.StatusCode = 100;
                response.StatusMessage = "Event creation Failed";
            }
            return response;

        }

        public Response EventsList( SqlConnection connection)

        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("Select * FROM Events WHERE IsActive=1 ", connection);

            
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Events> lstEvents = new List<Events>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++) 
                {
                    Events event_ = new Events();
                    event_.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    event_.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    event_.Content = Convert.ToString(dt.Rows[i]["Content"]);
                    event_.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    event_.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    event_.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);

                    lstEvents.Add(event_);



                }
                if (lstEvents.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Event data found";
                    response.listEvents = lstEvents;

                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No Event data found";
                    response.listEvents = null;


                }


            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Article data found";
                response.listNews = null;

            }

            return response;

        }

    }
}
