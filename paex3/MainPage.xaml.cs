using Newtonsoft.Json;
using paex3.modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace paex3
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.17.51/paex/post.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<Estudiante> dEstudiante;

        public MainPage()
        {
            InitializeComponent();
            mostrar();
        }

        public async void mostrar()
        {
            var content = await cliente.GetStringAsync(Url);
            List<Estudiante> getEstudiante = JsonConvert.DeserializeObject<List<Estudiante>>(content);

            dEstudiante = new ObservableCollection<Estudiante>(getEstudiante);

            listaEstudiantes.ItemsSource = dEstudiante;

        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new paginas.registro());

        }

        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objeto = (Estudiante) e.SelectedItem;

            Navigation.PushAsync(new paginas.editareliminar(objeto));
        }
    }
}
