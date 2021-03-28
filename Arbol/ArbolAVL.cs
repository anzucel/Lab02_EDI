﻿using System;
using Arbol; 

namespace ArbolAVL
{
    public class ArbolAVL<T>:Nodo<T>
    {
        public Nodo<T> Raiz;
        public int Contador;

        public ArbolAVL()
        {
            Raiz = null;
            Contador = 0;
        }

        ~ArbolAVL() { }

        //Factor de equilibrio 
        public int CalcFe(Nodo<T> nodo)
        {
            if(nodo == null)
            {
                return -1;
            }
            else
            {
                return nodo.Fe;
            }
        }

        public Nodo<T> RotarIzquierda(Nodo<T> nodo)
        {
            Nodo<T> aux = nodo.izquierda;
            nodo.izquierda = aux.derecha;
            aux.derecha = nodo;

            nodo.Fe = Math.Max(CalcFe(nodo.izquierda), CalcFe(nodo.derecha)) + 1;
            aux.Fe = Math.Max(CalcFe(aux.izquierda), nodo.Fe) + 1;

            return aux; 
        }

        public Nodo<T> RotarDerecha(Nodo<T> nodo)
        {
            Nodo<T> aux = nodo.derecha;
            nodo.derecha = aux.izquierda;
            aux.izquierda = nodo;

            nodo.Fe = Math.Max(CalcFe(nodo.izquierda), CalcFe(nodo.derecha)) + 1;
            //aux.Fe = Math.Max(CalcFe(aux.izquierda), CalcFe(aux.derecha)) + 1;
            aux.Fe = Math.Max(CalcFe(aux.derecha), nodo.Fe) + 1;
            //CalcFe(aux.derecha)
            return aux;
        }

        public Nodo<T> RDobleIzquierda(Nodo<T> nodo)
        {
            Nodo<T> aux;
            nodo.izquierda = RotarDerecha(nodo.izquierda);
            aux = RotarIzquierda(nodo);

            return aux;
        }

        public Nodo<T> RDobleDerecha(Nodo<T> nodo)
        {
            Nodo<T> aux;
            nodo.derecha = RotarIzquierda(nodo.derecha);
            aux = RotarDerecha(nodo);

            return aux; 
        }

        public Nodo<T> Balancear(Nodo<T> actual)
        {
            Nodo<T> raiz = actual;
            if (((CalcFe(actual.derecha)) - CalcFe(actual.izquierda)) == 2)
            {
                raiz = RotarDerecha(actual);
                Balancear(raiz);
            }
            else if ((CalcFe(actual.derecha) - CalcFe(actual.izquierda)) == -2)
            {
                raiz = RotarIzquierda(actual);
                Balancear(raiz);
            }

            return raiz;
        }
    }
}
