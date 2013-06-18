using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Allows you to obtain the method or property name of the caller.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Parameter, Inherited = false)]
    public sealed class CallerMemberNameAttribute : Attribute { }
}
