using paex3.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace paex3.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class editareliminar : ContentPage
    {
        public editareliminar(Estudiante datos)
        {
            InitializeComponent();
            txtCodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre.ToString();
            txtApellido.Text = datos.apellido.ToString();
            txtEdad.Text = datos.edad.ToString();

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

            try
            {

                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues("http://192.168.17.51/paex/post.php?codigo=" + txtCodigo.Text + "&Nombre=" + txtNombre.Text + "&Apellido=" + txtApellido.Text + "&Edad=" + txtEdad.Text, "PUT", parametros);

                Navigation.PushAsync(new MainPage());
                DisplayAlert("Usuario Actualizado", "", "Cerrar");
                   



            }
            catch
            {

            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

            try
            {

                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", txtCodigo.Text);

                cliente.UploadValues("http://192.168.17.51/paex/post.php?codigo=" + txtCodigo.Text, "DELETE", parametros);

                Navigation.PushAsync(new MainPage());

                DisplayAlert("Usuario eliminado", "", "Cerrar");



            }
            catch
            {

            }

        }
    }
}