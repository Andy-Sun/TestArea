﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace MyMVVM
{
    public class MyEvent : TriggerAction<DependencyObject>
    {

        /// <summary>
        /// 事件要绑定的命令
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(MyEvent), new PropertyMetadata(null));

        /// <summary>
        /// 绑定命令的参数，保持为空就是事件的参数
        /// </summary>
        public object CommandParateter
        {
            get { return (object)GetValue(CommandParateterProperty); }
            set { SetValue(CommandParateterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParateter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParateterProperty =
            DependencyProperty.Register("CommandParateter", typeof(object), typeof(MyEvent), new PropertyMetadata(null));

        //执行事件
        protected override void Invoke(object parameter)
        {
            if (CommandParateter != null)
                parameter = CommandParateter;
            if (Command != null)
                Command.Execute(parameter);
        }
    }
}
