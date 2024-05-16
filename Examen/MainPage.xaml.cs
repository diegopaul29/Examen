using Examen.Models;

namespace Examen
{
    public partial class MainPage : ContentPage
    {
        private string ApiUrl = "https://appcloudutnweb.azurewebsites.net/api/Artists";

        public MainPage()
        {
            InitializeComponent();
        }

        private void cmdCreate_Clicked(object sender, EventArgs e)
        {
            var resultado = APIConsumer.Crud<Artist>.Create(ApiUrl, new Artist
            {
                Id = 0,
                Name = txtNameArtist.Text,
                LastName = txtLastName.Text,
                Nationality = txtNationality.Text,
                BirthDate = txtBirthDate.Text
            });

            if (resultado != null)
            {
                txtId.Text = resultado.Id.ToString();
            }
        }

        private void cmdRead_Clicked(object sender, EventArgs e)
        {
            var resultado = APIConsumer.Crud<Artist>.Read_ById(ApiUrl, int.Parse(txtId.Text));
            if (resultado != null)
            {
                txtId.Text = resultado.Id.ToString();
                txtNameArtist.Text = resultado.Name;
                txtLastName.Text = resultado.LastName;
                txtNationality.Text = resultado.Nationality;
                txtBirthDate.Text = resultado.BirthDate;
            }
        }

        private void cmdUpdate_Clicked(object sender, EventArgs e)
        {
            APIConsumer.Crud<Artist>.Update(ApiUrl, int.Parse(txtId.Text), new Artist
            {
                Id = int.Parse(txtId.Text),
                Name = txtNameArtist.Text,
                LastName = txtLastName.Text,
                Nationality = txtNationality.Text,
                BirthDate = txtBirthDate.Text
            });
        }

        private void cmdDelete_Clicked(object sender, EventArgs e)
        {
            APIConsumer.Crud<Artist>.Delete(ApiUrl, int.Parse(txtId.Text));
            txtId.Text = "";
            txtNameArtist.Text = "";
            txtLastName.Text = "";
            txtNationality.Text = "";
            txtBirthDate.Text = "";
        }

        private string ApiUrlArt = "https://appcloudutnweb.azurewebsites.net/api/Artworks";

        private void cmdCreateArt_Clicked(object sender, EventArgs e)
        {
            var art = APIConsumer.Crud<Artwork>.Create(ApiUrlArt, new Artwork
            {
                Id = 0,
                Name = txtArtwork.Text,
                PublicationYear = txtYear.Text,
                Technique = txtTechnique.Text,
                Description = txtDescription.Text,
                Artistid = int.Parse(txtArtistId.Text)
            });

            if (art != null)
            {
                txtIdArtwork.Text = art.Id.ToString();
            }

        }

        private void cmdReadArt_Clicked(object sender, EventArgs e)
        {
            var art = APIConsumer.Crud<Artwork>.Read_ById(ApiUrlArt, int.Parse(txtIdArtwork.Text));
            if (art != null)
            {
                txtIdArtwork.Text = art.Id.ToString();
                txtArtwork.Text = art.Name;
                txtYear.Text = art.PublicationYear;
                txtTechnique.Text = art.Technique;
                txtDescription.Text = art.Description;
                txtArtistId.Text = art.Artistid.ToString();
            }
        }

        private void cmdUpdateArt_Clicked(object sender, EventArgs e)
        {
            APIConsumer.Crud<Artwork>.Update(ApiUrlArt, int.Parse(txtIdArtwork.Text), new Artwork
            {
                Id = int.Parse(txtIdArtwork.Text),
                Name = txtArtwork.Text,
                PublicationYear = txtYear.Text,
                Technique = txtTechnique.Text,
                Description = txtDescription.Text,
                Artistid = int.Parse(txtArtistId.Text),
            });
        }

        private void cmdDeleteArt_Clicked(object sender, EventArgs e)
        {
            APIConsumer.Crud<Artwork>.Delete(ApiUrlArt, int.Parse(txtIdArtwork.Text));
            txtIdArtwork.Text = "";
            txtArtwork.Text = "";
            txtYear.Text = "";
            txtTechnique.Text = "";
            txtDescription.Text = "";
            txtArtistId.Text = "";
        }
    }

}
