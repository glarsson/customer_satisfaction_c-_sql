using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace satisfaction
{
    public partial class _default : System.Web.UI.Page
    {

        protected void submitClick(object sender, EventArgs e)
        {
            // initialize forms output variables
            int formsRating = 0;
            string formsComment = null;
            string ticketQueryString = "not set";
            string sanitizedTicketQueryString = null;

            // grab data from forms and query string
            if (Request.Form["rating"] != null)
            {
                formsRating = System.Convert.ToInt32(Request.Form["rating"]);
            }
            if (Request.Form["comment"] != null)
            {
                formsComment = Request.Form["comment"];
            }
            ticketQueryString = Request.QueryString["ticket"];

            // sanitize user input text
            string sanitizedUserComment = Regex.Replace(formsComment, "\\p{C}+", "");
            char[] arr = sanitizedUserComment.Where(c => (char.IsLetterOrDigit(c) ||
                                                          char.IsWhiteSpace(c) ||
                                                          c == '-')).ToArray();

            sanitizedUserComment = new string(arr); 


            // sanity check on ticket query string
            // make sure ticket query string is not empty
            if (ticketQueryString != null)
            {
                // make sure ticket parameter string is 15 characters long
                if (ticketQueryString.Length == 15)
                {
                    // make sure that ticket parameter starts with INC
                    if (ticketQueryString.StartsWith("INC"))
                    {
                        // further check that all characters after INC are numbers
                        if (Regex.Match(ticketQueryString, @"\d{12}$").Success)
                        {
                            // looks like checks are good, lets go ahead and try to write to the database
                            try
                            {
                                using (var ctx = new SatisfactionContext())
                                {
                                    var newRating = new Rating() { Date = DateTime.Now, Ticket = ticketQueryString, Score = formsRating, Comment = sanitizedUserComment };
                                    ctx.Ratings.Add(newRating);
                                    ctx.SaveChanges();
                                }
                                Response.Redirect("~/success.aspx");
                            }
                            catch
                            {
                                Response.Write("Could not write to database, please contact your system administrator.");
                            }
                        }
                    }
                }
            }





        }

        public string ticketQueryStringSanitized = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            // initialize string for QueryString
            string ticketQueryString = "not set";

            // grab QueryString on page load
            ticketQueryString = Request.QueryString["ticket"];


            // sanity check on ticket query string
            // make sure ticket query string is not empty
            if (ticketQueryString != null)
            {
                // make sure ticket parameter string is 15 characters long
                if (ticketQueryString.Length == 15)
                {
                    // make sure that ticket parameter starts with INC
                    if (ticketQueryString.StartsWith("INC"))
                    {
                        // further check that all characters after INC are numbers
                        if (Regex.Match(ticketQueryString, @"\d{12}$").Success)
                        {
                            // lets write to ticketQueryStringSanitized so we can display that on the main page
                            ticketQueryStringSanitized = ticketQueryString;
                        }
                    }
                }
            }



                            // fetch query string parameters - this method has been deprecated in favor of forms
                            //string parameterTicket = Request.QueryString["ticket"];
                            //string parameterQuality = Request.QueryString["quality"];





                            /*
                                            // make sure parameters are provided - this method has been deprecated in favor of forms
                                            if (parameterTicket != null && parameterQuality != null)
                                            {
                                                // make sure string is 15 characters long
                                                if (parameterTicket.Length == 15)
                                                {
                                                    // make sure that ticket parameter starts with INC
                                                    if (parameterTicket.StartsWith("INC"))
                                                    {
                                                        // further check that all characters after INC are numbers
                                                        if (Regex.Match(parameterTicket, @"\d{12}$").Success)
                                                        {
                                                            // check that quality parameter is a number between 1 and 5
                                                            if (Enumerable.Range(1, 5).Contains(System.Convert.ToInt32(parameterQuality)))
                                                            {
                                                                // sanitization checks completed, lets write to database
                                                                try
                                                                {
                                                                    using (var ctx = new SatisfactionContext())
                                                                    {
                                                                        var newRating = new Rating() { Date = DateTime.Now, Ticket = parameterTicket, Score = System.Convert.ToInt32(parameterQuality) };
                                                                        ctx.Ratings.Add(newRating);
                                                                        ctx.SaveChanges();
                                                                    }
                                                                }
                                                                catch
                                                                {
                                                                    Response.Write("Could not write to database, please contact your system administrator.");
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        */
                        }
                    }
}