/*
 * Creado por SharpDevelop.
 * Usuario: Carlos Marichal
 * Fecha: 28-08-2018
 * Hora: 10:19 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Text;


namespace Ese
{
	/// <summary>
	/// Engloba la serializacion y desserializacion de mensajes
	/// </summary>
	class Mensaje
	{			
		public Comando comando;
		private int TamOrigen;
  		public string origen;
  		private int TamDestino;
  		public string destino;
  		private int TamMensaje;
  		public string mensaje;
  		
  		public Mensaje()
  		{
  			comando = Comando.Null;
  			TamOrigen  = 0;
  			TamDestino = 0;
  			TamMensaje = 0;
  			origen  = null;
  			destino = null;
  			mensaje = null;
  		}
  
  		public Mensaje(byte[] data)
  		{
   			int place = 0;
 			
   			comando = (Comando) BitConverter.ToInt32(data, place);
   			place += 4;
   			TamOrigen = BitConverter.ToInt32(data, place);
   			place += 4;
   			origen = Encoding.ASCII.GetString(data, place, TamOrigen);
   			place += TamOrigen;
   			TamDestino = BitConverter.ToInt32(data, place);
   			place += 4;
   			destino = Encoding.ASCII.GetString(data, place, TamDestino);
   			place += TamDestino;
   			TamMensaje = BitConverter.ToInt32(data, place);
   			place += 4;
   			mensaje = Encoding.ASCII.GetString(data, place, TamMensaje);
  		}
  
  		public byte[] GetBytes()
  		{
   			byte[] data = new byte[1024];
   			int place = 0;
  			
   			Buffer.BlockCopy(BitConverter.GetBytes((int)comando),0, data, place, 4);
   			place += 4;
   			Buffer.BlockCopy(BitConverter.GetBytes(origen.Length), 0, data, place, 4);
   			place += 4;
   			Buffer.BlockCopy(Encoding.ASCII.GetBytes(origen), 0, data, place, origen.Length);
   			place += origen.Length;
   			Buffer.BlockCopy(BitConverter.GetBytes(destino.Length), 0, data, place, 4);
   			place += 4;
   			Buffer.BlockCopy(Encoding.ASCII.GetBytes(destino), 0, data, place, destino.Length);
   			place += destino.Length;
   			Buffer.BlockCopy(BitConverter.GetBytes(mensaje.Length), 0, data, place, 4);
   			place += 4;
   			Buffer.BlockCopy(Encoding.ASCII.GetBytes(mensaje), 0, data, place, mensaje.Length);
   			
   			return data;
  		}
	}
}
