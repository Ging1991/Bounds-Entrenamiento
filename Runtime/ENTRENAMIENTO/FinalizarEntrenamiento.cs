using Bounds.Infraestructura;
using Bounds.Persistencia;

namespace Bounds.Entrenamiento {

	public class FinalizarEntrenamiento : IFinalizarDuelo {

		private readonly string codigo;
		private readonly LectorEntrenamiento lector;
		private readonly Billetera billetera;

		public FinalizarEntrenamiento(string codigo, LectorEntrenamiento lector, Billetera billetera) {
			this.codigo = codigo;
			this.lector = lector;
			this.billetera = billetera;
		}

		public void FinalizarDuelo(int jugadorGanador) {
			EntrenamientoBD entrenamientoBD = lector.LeerEntrenamientoBD(codigo);

			if (jugadorGanador == 1)
				entrenamientoBD.victorias++;
			else
				entrenamientoBD.derrotas++;
			lector.Guardar();

			billetera.GanarOro(500);
			ControlEscena escena = ControlEscena.GetInstancia();
			escena.CambiarEscena_entrenamiento();
		}

	}

}