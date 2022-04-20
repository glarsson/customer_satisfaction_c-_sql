using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace satisfaction
{
    public partial class reports_all_time : System.Web.UI.Page
    {
        // initialize public variable for average to display on web
        public string averageFinal = "no data";

        protected void Page_Load(object sender, EventArgs e)
        {
            // initialize variables used to calculate average
            int averageSum = 0;
            float averageCalculated;

            // read from database
            try
            {
                using (var ctx = new SatisfactionContext())
                {
                    // dump Ratings table to variable
                    var allRecordsContext = ctx.Ratings.ToList();

                    // initialize and feed the GridView with the data we selected
                    allRecordsGrid.DataSource = allRecordsContext;
                    allRecordsGrid.DataBind();

                    // iterate through ratings and add them up
                    foreach (Rating r in allRecordsContext)
                    {
                        averageSum = averageSum + r.Score;

                    }

                    // calculate the average
                    averageCalculated = (float)averageSum / allRecordsContext.Count;

                    // if there were no records we want to display "no data" instead of NaN
                    if (averageSum != 0)
                    {
                        // force only two decimals to be displayed
                        averageFinal = averageCalculated.ToString("0.00");
                    }
                }
            }
            catch
            {
                Response.Write("There was a problem reading from the database, please contact your system administrator.");
            }
        }
    }
}