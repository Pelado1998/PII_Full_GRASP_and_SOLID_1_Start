//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        //Cumple con Expert porque es el único responsable de conocer los datos de la receta
        //Cumple con SRP porque tiene una única razón de cambio que es cambiar los datos de la receta
        //Cumple con composite ya que toma objetos de varios tipos y compone uno nuevo en forma de arbol
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }
        public double GetProductionCost()
        {
            double cost = 0;
            if (this.steps.Count != 0)
            {
                foreach (Step step in this.steps)
                {
                    cost += step.Input.UnitCost + (step.Time * step.Equipment.HourlyCost);
                }
            }
            return cost;
        }
    }
}