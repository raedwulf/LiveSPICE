﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using SyMath;

namespace Circuit
{
    /// <summary>
    /// Simulate a circuit without any optimizations. 
    /// </summary>
    public class ReferenceSimulation : Simulation
    {
        // Stores any global state in the simulation.
        private Dictionary<Expression, Expression> state = new Dictionary<Expression, Expression>();
                
        /// <summary>
        /// Create a simulation for the given system solution.
        /// </summary>
        /// <param name="Transient">Transient solution to run.</param>
        /// <param name="Log">Log for simulation output.</param>
        public ReferenceSimulation(TransientSolution Transient, int Oversample, ILog Log) : base(Transient, Oversample, Log)
        {
            Reset();
        }

        public override void Reset()
        {
            base.Reset();

            // State for each node.
            foreach (Expression i in Transient.Nodes)
                state[i] = Constant.Zero;

            //// State for the state variables (differentials).
            //foreach (Arrow i in Transient.Differential)
            //    state[i.Left.Evaluate(t, t0)] = Constant.Zero;

            //// State for iterative unknowns
            //foreach (AlgebraicSystem i in Transient.Algebraic)
            //    foreach (Expression j in i.Unknowns)
            //        state[j.Evaluate(t, t0)] = Constant.Zero;

            //// State for the linearization.
            //foreach (Arrow i in Transient.Linearization)
            //    state[i.Left] = Constant.Zero;
        }

        protected override void Process(
            long n, double T,
            int N, 
            IEnumerable<KeyValuePair<Expression,double[]>> Input, 
            IEnumerable<KeyValuePair<Expression,double[]>> Output, 
            IEnumerable<Arrow> Arguments, 
            int Oversample, int Iterations)
        {
            throw new NotImplementedException();
        }
    }
}
