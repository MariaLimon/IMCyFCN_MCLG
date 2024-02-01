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
		double _peso;
		double _altura;
		int _latidos;
		double _resultado;

		#endregion
		#region CONSTRUCTOR
		public VMimcYFCN(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
		#region OBJETOS
		public double peso
		{
			get { return _peso; }
			set { SetValue(ref _peso, value); }
		}
		public double resultado
		{
			get { return _resultado; }
			set { SetValue(ref _resultado, value); }
		}
		public double altura
		{
			get { return _altura; }
			set { SetValue(ref _altura, value); }
		}
		public int latidos
		{
			get { return _latidos; }
			set { SetValue(ref _latidos, value); }
		}
		public bool IMCseleccionado
		{
			get { return _IMCseleccionado; }
			set { SetValue(ref _IMCseleccionado, value); }
		}
		#endregion
		#region PROCESOS
		Entry pesoM;
		Entry alturaM;
		Entry latidosM;
		public void MostrarDatos(bool IMCse)
		{
			
			if (IMCse)
			{
				pesoM.IsVisible = true;
				alturaM.IsVisible = true;
				latidosM.IsVisible = false;

			}
			else { 
				
			}
		}

		public void IMC()
		{
			double alnum = altura;
			double penum = peso;
			resultado= (penum / (alnum * alnum));
			
		}
		public void FCN()
		{
			int lanum = latidos;

			resultado =(lanum*4);
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
		public ICommand IMCCommand => new Command(IMC);

		public ICommand FCNCommand => new Command(FCN);

		#endregion
	}
}

