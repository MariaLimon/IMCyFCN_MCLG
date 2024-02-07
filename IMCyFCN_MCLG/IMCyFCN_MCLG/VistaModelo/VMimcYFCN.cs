using MvvmGuia.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;

namespace IMCyFCN_MCLG.VistaModelo
{
	public class VMimcYFCN : BaseViewModel
	{
		#region VARIABLES
		string _Texto;

		bool _IMCseleccionado;

		string _peso;
		string _altura;
		string _latidos;
		string _resultado;

		bool _pesoM;
		bool _alturaM;
		bool _latidosM;
		bool _imagenM;

		string _imagen;
		string _estado;


		#endregion
		#region CONSTRUCTOR
		public VMimcYFCN(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
		#region OBJETOS
		public string estado
		{
			get { return _estado; }
			set { SetValue(ref _estado, value); }
		}
		public string imagen
		{
			get { return _imagen; }
			set { SetValue(ref _imagen, value); }
		}
		public string peso
		{
			get { return _peso; }
			set { SetValue(ref _peso, value); }
		}
		public string resultado
		{
			get { return _resultado; }
			set { SetValue(ref _resultado, value); }
		}
		public string altura
		{
			get { return _altura; }
			set { SetValue(ref _altura, value); }
		}
		public string latidos
		{
			get { return _latidos; }
			set { SetValue(ref _latidos, value); }
		}

		public bool imagenM
		{
			get { return _imagenM; }
			set { SetValue(ref _imagenM, value); }
		}
		public bool IMCseleccionado
		{
			get { return _IMCseleccionado; }
			set
			{
				_IMCseleccionado = value;
				OnPropertyChanged();
				MostrarD(_IMCseleccionado);
			}
		}

		public bool alturaM
		{
			get { return _alturaM; }
			set
			{
				if (_alturaM != value)
				{
					_alturaM = value;
					OnPropertyChanged(nameof(alturaM));
				}
			}
		}
		public bool pesoM
		{
			get { return _pesoM; }
			set
			{
				if (_pesoM != value)
				{
					_pesoM = value;
					OnPropertyChanged(nameof(pesoM));
				}
			}
		}
		public bool latidosM
		{
			get { return _latidosM; }
			set
			{
				if (_latidosM != value)
				{
					_latidosM = value;
					OnPropertyChanged(nameof(latidosM));
				}
			}
		}
		#endregion
		#region PROCESOS


		public void MostrarD(bool IMCse)
		{

			if (IMCse)
			{
				pesoM = true;
				alturaM = true;
				latidosM = false;

			}
			else
			{
				pesoM = false;
				alturaM = false;
				latidosM = true;
			}
		}

		public void CalculoBoton()
		{
			if (IMCseleccionado)
			{
				double alnum = Convert.ToDouble(altura);
				double penum = Convert.ToDouble(peso);
				resultado = Convert.ToString(penum / (alnum * alnum));
				
			}
			else
			{
				int lanum = Convert.ToInt16(latidos);
				resultado = Convert.ToString(lanum * 4);
			}
			imagen = "true";
			ImagenAMostrar();
		}
		public void ImagenAMostrar()
		{
			double resu = Convert.ToDouble(resultado);

			if (IMCseleccionado)
			{
				if (resu <= 18.5)
				{
					imagen = "crisis.png";
					estado = "peso insuficiente";
				}
				else if (resu >= 18.5 && resu <= 24.9)
				{
					imagen = "comprobar.png";
					estado = "peso normal";
				}
				else if(resu>=25.0 && resu <= 29.9)
				{
					imagen = "crisis.png";
					estado = "sobrepeso";
				}
				else
				{
					imagen = "crisis.png";
					estado = "obesidad";
				}
			}
			else
			{
				if(resu <= 60)
				{
					imagen = "crisis.png";
					estado = "FC bajo";
				}
				else if(resu > 60 && resu <= 100)
				{
					imagen = "comprobar.png";
					estado = "FC normal";
				}
				else
				{
					imagen = "crisis.png";
					estado = "FC alta";
				}
			}

		}

		/*
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
		*/

		#endregion
		#region COMANDOS
		public ICommand ProcesoMostrarCommand => new Command<bool>(p => MostrarD(p));
		public ICommand CalcularBotonommand => new Command(CalculoBoton);

		#endregion
	}
}

