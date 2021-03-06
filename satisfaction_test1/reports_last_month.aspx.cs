using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace satisfaction
{
    public partial class reports_last_month : System.Web.UI.Page
    {
        // initialize variable for average to display on web
        public string averageFinal = "no data";


        protected void Page_Load(object sender, EventArgs e)
        {
            // initialize variables used to calculate average
            int averageSum = 0;
            float averageCalculated;

            DateTime lastMonthsDate = DateTime.Now.AddMonths(-1);
            // read from database
            //try
            //{
                // define database context
                using (var ctx = new SatisfactionContext())
                {
                    // dump Ratings table to variable
                    var lastMonthsRecordsContext = ctx.Ratings.ToList();

                    // initialize list of Ratings to hold whatever records we want to grab
                    List<Rating> lastMonthsRecords = new List<Rating>();

                    // interate through the records and select what we need
                    foreach (Rating r in lastMonthsRecordsContext)
                    {
                        if (r.Date.Month == lastMonthsDate.Month)
                        {
                            lastMonthsRecords.Add(r);
                            averageSum = averageSum + r.Score;
                        }
                    }

                    // calculate the average
                    averageCalculated = (float)averageSum / lastMonthsRecords.Count;

                    // if there were no records we want to display "no data" instead of NaN
                    if (averageSum != 0)
                    {
                        // force only two decimals to be displayed
                        averageFinal = averageCalculated.ToString("0.00");
                    }

                    // initialize and feed the GridView with the data we selected
                    lastMonthsRecordsGrid.DataSource = lastMonthsRecords;
                    lastMonthsRecordsGrid.DataBind();
                }
            //}
            //catch
            //{
            //    Response.Write("There was a problem reading from the database, please contact your system administrator.");
            //}
        }
    }
}