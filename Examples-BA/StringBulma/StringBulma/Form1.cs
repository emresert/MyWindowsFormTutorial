using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;


namespace StringBulma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WebClient wc = new WebClient();
        Movie _movie = new Movie();
        List<Movie> movieList = new List<Movie>();
      
        
        private void Form1_Load(object sender, EventArgs e)
        {
          
          
        }     
        private void btnGoster_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string result = wc.DownloadString("https://www.imdb.com/find?ref_=nv_sr_fn&q=" + textBox1.Text.Trim() + "&s=all");
            string[] linkValues = result.Split(new string[] { "<td class=\"result_text\"> "}, StringSplitOptions.RemoveEmptyEntries);
            string[] nameValues = result.Split(new string[] { "<td class=\"result_text\"> " }, StringSplitOptions.RemoveEmptyEntries);
            string[] totalValues = new string[linkValues.Length - 1 ];

            for (int i = 1; i < linkValues.Length; i++)
                {
                linkValues[i] = linkValues[i].Replace("\"", "*");
                linkValues[i] = linkValues[i].Replace("<", "@");
                linkValues[i] = linkValues[i].Replace(">", "#");
                int indexAt = linkValues[i].IndexOf("*", 0);
                int lastIndexAt = linkValues[i].IndexOf("*", linkValues[i].IndexOf("*") + 1);
                linkValues[i] = linkValues[i].Substring(indexAt + 1, lastIndexAt - (indexAt + 1));
                _movie.link = linkValues[i];

                nameValues[i] = nameValues[i].Replace("\"", "*");
                nameValues[i] = nameValues[i].Replace("<", "@");
                nameValues[i] = nameValues[i].Replace(">", "#");
                nameValues[i] = nameValues[i];
                int _indexAt  = nameValues[i].IndexOf("#", 0);
                int _lastIndexAt = nameValues[i].IndexOf("@", 1);
                nameValues[i] = nameValues[i].Substring(_indexAt + 1,(_lastIndexAt-_indexAt)-1);
                _movie.ad = nameValues[i];

                totalValues[i-1] = _movie.ad.ToString() + " " +  _movie.link.ToString();
             
                movieList.Add(_movie);


                /*listBox1.Items.Add(new Movie
                {
                    ad = _movie.ad,
                    link = _movie.link
                });*/

                
            }

            listBox1.Items.AddRange(totalValues);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string linkItem = listBox1.GetItemText(listBox1.SelectedItem);
            int indexAt = linkItem.IndexOf("/", 0);
            string url = linkItem.Substring(indexAt, linkItem.Length - indexAt);
            string descriptionResult = wc.DownloadString("https://www.imdb.com" + url);
            string authorResult = wc.DownloadString("https://www.imdb.com" + url);
            string[] descriptionValues = descriptionResult.Split(new string[] { "<div class=\"summary_text\">" }, StringSplitOptions.RemoveEmptyEntries);
            string[] directorsInfo;
            for (int i = 1; i < descriptionValues.Length; i++)
            {
                descriptionValues[i] = descriptionValues[i].Replace("<", "*");
                int _indexAt = descriptionValues[i].IndexOf("*", 0);
                lblDescription.Text = descriptionValues[i].Substring(0, _indexAt).Trim();
            }
            string[] authorValues = authorResult.Split(new string[] { "<div class=\"credit_summary_item\">" }, StringSplitOptions.RemoveEmptyEntries);
            string directors, writer, stars;
            int indexForStart,indexForEnd;
            string headerTest;
            for (int i = 1; i < authorValues.Length; i++)
            {

                headerTest = authorValues[i].Trim().Substring(19,1);


                if (headerTest == "D") {
                    directors = authorValues[i].Trim();
                    directors = directors.Replace("</h4>","*").Trim();
                    directors = directors.Replace("</div>","*").Trim();
                    directors = directors.Replace("<a href=\"","").Trim();
                    directors = directors.Replace("</a>", "").Trim();
                    directors = directors.Replace(">", "").Trim();
                    directors = directors.Replace("\"", "").Trim();
                    indexForEnd = directors.LastIndexOf("*");
                    indexForStart = directors.IndexOf("*", 0);
                    directors = directors.Substring(indexForStart +1  ,(indexForEnd -1) - indexForStart);
                    lblYonetmen.Text = directors;
                    if (directors.IndexOf(",",0) != -1)
                    {
                        directorsInfo = directors.Split(',');
                    }
                    else
                    {
                        directors = directors + ",";
                        directorsInfo = directors.Split(',');
                    }
                    
                }
                else if(headerTest == "W") {
                    writer = authorValues[i].Trim();
                }
                else if(headerTest == "S")
                {
                    int point = authorValues[i].IndexOf("|", 0);
                    stars = authorValues[i].Substring(0,point).Trim();
                }
            }



        }
    }
}

/*
 int indexForN = linkValues[i].IndexOf("n", 0);
                if(indexForN !=1) {
                    _movie.link = linkValues[i];
                }
                linkValues[i] = linkValues[i];
     
     */
/* listBox1.Items.Add(new 
                {
                    ad = _movie.ad,
                    link = _movie.link
                });*/
