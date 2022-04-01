﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace hilos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void correrProceso()
        {
            CambiarProgreso("Iniciando proceso...", 0);
            //hagamos un ciclo que se repita 100 veces 
            for (int i = 0; i < 100; i++)
            {
                //esperaremos medio segundo en cada iteración 
                Thread.Sleep(500);
                //notificamos el avance al usuario 
                CambiarProgreso(string.Format("Posición {0}...", i), i);
            }
            CambiarProgreso("Completado :D", 100);
            MessageBox.Show("Proceso Terminado!");
        }

        private void btnMostrarMsg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Holaaaaaa estudiantes del Tec Hilos!");
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            ThreadStart delegado = new ThreadStart(correrProceso);

            Thread hilo = new Thread(delegado);
            hilo.Start();
        }

        delegate void CambiarProgresoDelegado(string texto, int valor);
        private void CambiarProgreso(string texto, int valor)
        {
            if (this.InvokeRequired)
            {
                CambiarProgresoDelegado delegado = new CambiarProgresoDelegado(CambiarProgreso);
                object[] parametros = new object[] { texto, valor };
                this.Invoke(delegado, parametros);

            }
            else
            {
            lbProgreso.Text = texto;
            prbProgreso.Value = valor;
            }

          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
