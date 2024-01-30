using MvvmGuia.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace IMCyFCN_MCLG.VistaModelo
{
	public class VMimcYFCN : BaseViewModel
	{
		#region VARIABLES
		string _Texto;
		bool _IMCseleccionado;
		Entry _peso;
		Entry _altura;
		Entry _latidos;
		#endregion
		#region CONSTRUCTOR
		public VMimcYFCN(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
		#region OBJETOS
		public Entry peso
		{
			get { return _peso; }
			set { SetValue(ref _peso, value); }
		}
		public Entry altura
		{
			get { return _altura; }
			set { SetValue(ref _altura, value); }
		}
		public Entry latidos
		{
			get { return _altura; }
			set { SetValue(ref _altura, value); }
		}
		public bool IMCseleccionado
		{
			get { return _IMCseleccionado; }
			set { SetValue(ref _IMCseleccionado, value); }
		}
		#endregion
		#region PROCESOS
		public void MostrarDatos(bool IMCse)
		{
			
			if (IMCse)
			{
				peso.IsVisible = true;
				altura.IsVisible = true;
				latidos.IsVisible = false;
			}
			else { 
				peso.IsVisible = false; 
				altura.IsVisible = false; 
				latidos.IsVisible = true; 
			}
		}
		public async Task ProcesoAsyncrono()
		{
			await DisplayAlert("Titulo", "Mensaje", "Ok");
		}
		public void ProcesoSimple()
		{

		}
		#endregion
		#region COMANDOS
		public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
		public ICommand ProcesoMostrarCommand => new Command<bool>(p => MostrarDatos(p));
		#endregion
	}
}

