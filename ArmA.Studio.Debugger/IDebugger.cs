﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmA.Studio.Debugger
{
    public interface IDebugger :  IDisposable
    {
        event EventHandler<OnHaltEventArgs> OnHalt;
        event EventHandler<OnExceptionEventArgs> OnException;
        event EventHandler<OnErrorEventArgs> OnError;
        event EventHandler<OnConnectionLostEventArgs> OnConnectionClosed;

        void SetBreakpoint(Breakpoint b, bool flag);
        void UpdateBreakpoint(Breakpoint b);
        void ClearBreakpoints();

        bool Attach();
        void Detach();

        Variable GetVariableByName(string name);
        Variable SetVariable(Variable v);
        IEnumerable<Variable> GetVariables();

        Callstack GetCallstack();
        bool Perform(EOperation stepInto);
        string GetLastError();
    }
}
