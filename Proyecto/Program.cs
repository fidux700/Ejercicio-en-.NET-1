using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numProveedorActual = 0;
            int montoActual;
            int montoMaximoAcumulado = 0;
            int montoFCA = 0;
            int montoFCB = 0;
            int montoFCC = 0;
            int montoTotalA;
            int montoTotalB = 0;
            int montoTotalC = 0;
            int numProductoActual = 0;
            int montoMinimoAcumulado = 0;
            int contadorCompras = 0;
            int proveedorDeMaximo = 0;
            int numCompradaAcumulado = 0;
            int proveedorPuntoE = 0;
            int productoPuntoE = 0;
            int contadorMesAgosto = 0;
            Console.WriteLine("Indique numero de proveedor (Ingrese cero si desea finalizar el programa)");
            int numProveedor = int.Parse(Console.ReadLine());

            while (numProveedor != 0)
            {
                numProveedorActual = numProveedor;
                contadorCompras = 0;
                while (numProveedor == numProveedorActual)
                {
                    Console.WriteLine("Indique día del mes");
                    int numDia = int.Parse(Console.ReadLine());
                    Console.WriteLine("Indique mes del año");
                    int numMes = int.Parse(Console.ReadLine());
                    Console.WriteLine("Indique tipo de factura: Responsable inscripto: A (1),Consumidor Final: B(2), o Monotributo: C(3)");
                    int numFactura = int.Parse(Console.ReadLine());
                    Console.WriteLine("Indique numero de producto (número no correlativo)");
                    int numProducto = int.Parse(Console.ReadLine());
                    Console.WriteLine("Cantidad a comprar");
                    int numCantidadComprada = int.Parse(Console.ReadLine());
                    Console.WriteLine("Precio unitario del producto");
                    int numPrecioUnidad = int.Parse(Console.ReadLine());
                    //INICIO PUNTO A --------------------------- 
                    montoActual = numCantidadComprada *= numPrecioUnidad;
                    if (montoActual >= montoMaximoAcumulado)
                    {
                        montoMaximoAcumulado = montoActual;
                        proveedorDeMaximo = numProveedor;
                    }
                    //FIN PUNTO A --------------------------- 
                    //INICIO PUNTO B --------------------------- 
                    if (numFactura == 1)
                    {
                        montoTotalA = montoActual += montoFCA;
                        montoFCA = montoTotalA;
                    }
                    else if (numFactura == 2)
                    {
                        montoTotalB = montoActual += montoFCB;
                        montoFCB = montoTotalB;
                    }
                    else if (numFactura == 3)
                    {
                        montoTotalC = montoActual += montoFCC;
                        montoFCC = montoTotalC;
                    }
                    //FIN PUNTO B --------------------------- 
                    //INICIO PUNTO C --------------------------- 
                    if (numMes == 8 && montoActual <= montoMinimoAcumulado && contadorMesAgosto > 0)
                    {
                        montoMinimoAcumulado = montoActual;
                        numProductoActual = numProducto;
                    }
                    else if (numMes == 8 && montoActual >= 0 && contadorMesAgosto == 0)
                    {
                        montoMinimoAcumulado = montoActual;
                        contadorMesAgosto++;
                    }
                    //FIN PUNTO C --------------------------- 
                    //INICIO PUNTO D --------------------------- 
                    contadorCompras++;
                    //FIN PUNTO D --------------------------- 
                    //INICIO PUNTO E --------------------------- 
                    if (numCantidadComprada >= numCompradaAcumulado)
                    {
                        numCompradaAcumulado = numCantidadComprada;
                        proveedorPuntoE = numProveedor;
                        productoPuntoE = numProducto;
                    }
                    //FIN PUNTO E --------------------------- 
                    //PUNTO D 
                    Console.WriteLine($"[PUNTO D] La cantidad de compras del proveedor {numProveedor} al momento es de: {contadorCompras}");
                    Console.WriteLine("\n\nIndique numero de proveedor (Ingrese cero si desea finalizar el programa)");
                    numProveedor = int.Parse(Console.ReadLine());

                }


            }
            //PUNTO A 
            Console.WriteLine($"\n\n[PUNTO A] El monto maximo registrado es {montoMaximoAcumulado} y corresponde al proveedor {proveedorDeMaximo}");
            //PUNTO B 
            Console.WriteLine($"\n[PUNTO B] La inversión total de todo el año es Factura A {montoFCA}, Factura B {montoFCB}, Factura C {montoFCC}");
            //PUNTO C 
            Console.WriteLine($"\n[PUNTO C] La compra de menor monto del mes de Agosto es {montoMinimoAcumulado}, producto {numProductoActual}");
            //PUNTO E 
            Console.WriteLine($"\n[PUNTO E] El producto más solicitado en una compra fué el: {productoPuntoE}, correspondiente al proveedor {proveedorPuntoE}");



        }
    }
}
