using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;


namespace ejemplos_ado_net
{
    public partial class frmPokemon : Form
    {
        private List<Pokemon> listaPokemon;
        public frmPokemon()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            listaPokemon = negocio.listar();
            dgvPokemons.DataSource = listaPokemon;
            dgvPokemons.Columns["UrlImagen"].Visible = false;
            cargarImagen(listaPokemon[0].UrlImagen);
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);
        }

        private void cargarImagen(string imagen)
        {
            try
            {

                pbxPokemon.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxPokemon.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }
    }
}
