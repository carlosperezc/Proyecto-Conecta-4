﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatJuego.Cliente.Proxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Jugador", Namespace="http://schemas.datacontract.org/2004/07/ChatJuego.Base_de_datos")]
    [System.SerializableAttribute()]
    public partial class Jugador : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int JugadorIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string contraseniaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string correoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<float> puntajeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usuarioField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int JugadorId {
            get {
                return this.JugadorIdField;
            }
            set {
                if ((this.JugadorIdField.Equals(value) != true)) {
                    this.JugadorIdField = value;
                    this.RaisePropertyChanged("JugadorId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string contrasenia {
            get {
                return this.contraseniaField;
            }
            set {
                if ((object.ReferenceEquals(this.contraseniaField, value) != true)) {
                    this.contraseniaField = value;
                    this.RaisePropertyChanged("contrasenia");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string correo {
            get {
                return this.correoField;
            }
            set {
                if ((object.ReferenceEquals(this.correoField, value) != true)) {
                    this.correoField = value;
                    this.RaisePropertyChanged("correo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<float> puntaje {
            get {
                return this.puntajeField;
            }
            set {
                if ((this.puntajeField.Equals(value) != true)) {
                    this.puntajeField = value;
                    this.RaisePropertyChanged("puntaje");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string usuario {
            get {
                return this.usuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.usuarioField, value) != true)) {
                    this.usuarioField = value;
                    this.RaisePropertyChanged("usuario");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EstadoDeRegistro", Namespace="http://schemas.datacontract.org/2004/07/ChatJuego.Base_de_datos")]
    public enum EstadoDeRegistro : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Correcto = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FallidoPorCorreo = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FallidoPorUsuario = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fallido = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Mensaje", Namespace="http://schemas.datacontract.org/2004/07/ChatJuego.Host")]
    [System.SerializableAttribute()]
    public partial class Mensaje : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContenidoMensajeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TiempoDeEnvioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioEmisorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioReceptorField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ContenidoMensaje {
            get {
                return this.ContenidoMensajeField;
            }
            set {
                if ((object.ReferenceEquals(this.ContenidoMensajeField, value) != true)) {
                    this.ContenidoMensajeField = value;
                    this.RaisePropertyChanged("ContenidoMensaje");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TiempoDeEnvio {
            get {
                return this.TiempoDeEnvioField;
            }
            set {
                if ((this.TiempoDeEnvioField.Equals(value) != true)) {
                    this.TiempoDeEnvioField = value;
                    this.RaisePropertyChanged("TiempoDeEnvio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UsuarioEmisor {
            get {
                return this.UsuarioEmisorField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioEmisorField, value) != true)) {
                    this.UsuarioEmisorField = value;
                    this.RaisePropertyChanged("UsuarioEmisor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UsuarioReceptor {
            get {
                return this.UsuarioReceptorField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioReceptorField, value) != true)) {
                    this.UsuarioReceptorField = value;
                    this.RaisePropertyChanged("UsuarioReceptor");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChatServicio.EstadoDeEnvio", Namespace="http://schemas.datacontract.org/2004/07/ChatJuego.Host")]
    public enum ChatServicioEstadoDeEnvio : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Correcto = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UsuarioNoEncontrado = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fallido = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Proxy.IChatServicio", CallbackContract=typeof(ChatJuego.Cliente.Proxy.IChatServicioCallback))]
    public interface IChatServicio {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatServicio/conectarse", ReplyAction="http://tempuri.org/IChatServicio/conectarseResponse")]
        bool conectarse(ChatJuego.Cliente.Proxy.Jugador jugador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatServicio/conectarse", ReplyAction="http://tempuri.org/IChatServicio/conectarseResponse")]
        System.Threading.Tasks.Task<bool> conectarseAsync(ChatJuego.Cliente.Proxy.Jugador jugador);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/inicializar")]
        void inicializar();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/inicializar")]
        System.Threading.Tasks.Task inicializarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatServicio/registroJugador", ReplyAction="http://tempuri.org/IChatServicio/registroJugadorResponse")]
        ChatJuego.Cliente.Proxy.EstadoDeRegistro registroJugador(string usuario, string contrasenia, string correo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatServicio/registroJugador", ReplyAction="http://tempuri.org/IChatServicio/registroJugadorResponse")]
        System.Threading.Tasks.Task<ChatJuego.Cliente.Proxy.EstadoDeRegistro> registroJugadorAsync(string usuario, string contrasenia, string correo);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/mandarMensaje")]
        void mandarMensaje(ChatJuego.Cliente.Proxy.Mensaje mensaje);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/mandarMensaje")]
        System.Threading.Tasks.Task mandarMensajeAsync(ChatJuego.Cliente.Proxy.Mensaje mensaje);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/mandarMensajePrivado")]
        void mandarMensajePrivado(ChatJuego.Cliente.Proxy.Mensaje mensaje, string nombreJugador);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/mandarMensajePrivado")]
        System.Threading.Tasks.Task mandarMensajePrivadoAsync(ChatJuego.Cliente.Proxy.Mensaje mensaje, string nombreJugador);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/desconectarse")]
        void desconectarse();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/desconectarse")]
        System.Threading.Tasks.Task desconectarseAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/recuperarPuntajesDeJugadores")]
        void recuperarPuntajesDeJugadores();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/recuperarPuntajesDeJugadores")]
        System.Threading.Tasks.Task recuperarPuntajesDeJugadoresAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServicioCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/recibirMensaje")]
        void recibirMensaje(ChatJuego.Cliente.Proxy.Jugador jugador, ChatJuego.Cliente.Proxy.Mensaje mensaje, string[] nombresDeJugadores);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/actualizarJugadoresConectados")]
        void actualizarJugadoresConectados(string[] nombresDeJugadores);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChatServicio/mostrarPuntajes")]
        void mostrarPuntajes(ChatJuego.Cliente.Proxy.Jugador[] jugadores);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatServicioChannel : ChatJuego.Cliente.Proxy.IChatServicio, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatServicioClient : System.ServiceModel.DuplexClientBase<ChatJuego.Cliente.Proxy.IChatServicio>, ChatJuego.Cliente.Proxy.IChatServicio {
        
        public ChatServicioClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatServicioClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool conectarse(ChatJuego.Cliente.Proxy.Jugador jugador) {
            return base.Channel.conectarse(jugador);
        }
        
        public System.Threading.Tasks.Task<bool> conectarseAsync(ChatJuego.Cliente.Proxy.Jugador jugador) {
            return base.Channel.conectarseAsync(jugador);
        }
        
        public void inicializar() {
            base.Channel.inicializar();
        }
        
        public System.Threading.Tasks.Task inicializarAsync() {
            return base.Channel.inicializarAsync();
        }
        
        public ChatJuego.Cliente.Proxy.EstadoDeRegistro registroJugador(string usuario, string contrasenia, string correo) {
            return base.Channel.registroJugador(usuario, contrasenia, correo);
        }
        
        public System.Threading.Tasks.Task<ChatJuego.Cliente.Proxy.EstadoDeRegistro> registroJugadorAsync(string usuario, string contrasenia, string correo) {
            return base.Channel.registroJugadorAsync(usuario, contrasenia, correo);
        }
        
        public void mandarMensaje(ChatJuego.Cliente.Proxy.Mensaje mensaje) {
            base.Channel.mandarMensaje(mensaje);
        }
        
        public System.Threading.Tasks.Task mandarMensajeAsync(ChatJuego.Cliente.Proxy.Mensaje mensaje) {
            return base.Channel.mandarMensajeAsync(mensaje);
        }
        
        public void mandarMensajePrivado(ChatJuego.Cliente.Proxy.Mensaje mensaje, string nombreJugador) {
            base.Channel.mandarMensajePrivado(mensaje, nombreJugador);
        }
        
        public System.Threading.Tasks.Task mandarMensajePrivadoAsync(ChatJuego.Cliente.Proxy.Mensaje mensaje, string nombreJugador) {
            return base.Channel.mandarMensajePrivadoAsync(mensaje, nombreJugador);
        }
        
        public void desconectarse() {
            base.Channel.desconectarse();
        }
        
        public System.Threading.Tasks.Task desconectarseAsync() {
            return base.Channel.desconectarseAsync();
        }
        
        public void recuperarPuntajesDeJugadores() {
            base.Channel.recuperarPuntajesDeJugadores();
        }
        
        public System.Threading.Tasks.Task recuperarPuntajesDeJugadoresAsync() {
            return base.Channel.recuperarPuntajesDeJugadoresAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Proxy.IInvitacionCorreoServicio", CallbackContract=typeof(ChatJuego.Cliente.Proxy.IInvitacionCorreoServicioCallback))]
    public interface IInvitacionCorreoServicio {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInvitacionCorreoServicio/enviarInvitacion", ReplyAction="http://tempuri.org/IInvitacionCorreoServicio/enviarInvitacionResponse")]
        ChatJuego.Cliente.Proxy.ChatServicioEstadoDeEnvio enviarInvitacion(ChatJuego.Cliente.Proxy.Jugador jugadorInvitado, string codigoPartida, ChatJuego.Cliente.Proxy.Jugador jugadorInvitador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInvitacionCorreoServicio/enviarInvitacion", ReplyAction="http://tempuri.org/IInvitacionCorreoServicio/enviarInvitacionResponse")]
        System.Threading.Tasks.Task<ChatJuego.Cliente.Proxy.ChatServicioEstadoDeEnvio> enviarInvitacionAsync(ChatJuego.Cliente.Proxy.Jugador jugadorInvitado, string codigoPartida, ChatJuego.Cliente.Proxy.Jugador jugadorInvitador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInvitacionCorreoServicio/mandarCodigoDeRegistro", ReplyAction="http://tempuri.org/IInvitacionCorreoServicio/mandarCodigoDeRegistroResponse")]
        ChatJuego.Cliente.Proxy.ChatServicioEstadoDeEnvio mandarCodigoDeRegistro(string codigoDeRegistro, string correo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInvitacionCorreoServicio/mandarCodigoDeRegistro", ReplyAction="http://tempuri.org/IInvitacionCorreoServicio/mandarCodigoDeRegistroResponse")]
        System.Threading.Tasks.Task<ChatJuego.Cliente.Proxy.ChatServicioEstadoDeEnvio> mandarCodigoDeRegistroAsync(string codigoDeRegistro, string correo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IInvitacionCorreoServicioCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IInvitacionCorreoServicio/recibirMensaje")]
        void recibirMensaje(ChatJuego.Cliente.Proxy.Jugador jugador, ChatJuego.Cliente.Proxy.Mensaje mensaje, string[] nombresDeJugadores);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IInvitacionCorreoServicio/actualizarJugadoresConectados")]
        void actualizarJugadoresConectados(string[] nombresDeJugadores);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IInvitacionCorreoServicio/mostrarPuntajes")]
        void mostrarPuntajes(ChatJuego.Cliente.Proxy.Jugador[] jugadores);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IInvitacionCorreoServicioChannel : ChatJuego.Cliente.Proxy.IInvitacionCorreoServicio, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InvitacionCorreoServicioClient : System.ServiceModel.DuplexClientBase<ChatJuego.Cliente.Proxy.IInvitacionCorreoServicio>, ChatJuego.Cliente.Proxy.IInvitacionCorreoServicio {
        
        public InvitacionCorreoServicioClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public InvitacionCorreoServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public InvitacionCorreoServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public InvitacionCorreoServicioClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public InvitacionCorreoServicioClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public ChatJuego.Cliente.Proxy.ChatServicioEstadoDeEnvio enviarInvitacion(ChatJuego.Cliente.Proxy.Jugador jugadorInvitado, string codigoPartida, ChatJuego.Cliente.Proxy.Jugador jugadorInvitador) {
            return base.Channel.enviarInvitacion(jugadorInvitado, codigoPartida, jugadorInvitador);
        }
        
        public System.Threading.Tasks.Task<ChatJuego.Cliente.Proxy.ChatServicioEstadoDeEnvio> enviarInvitacionAsync(ChatJuego.Cliente.Proxy.Jugador jugadorInvitado, string codigoPartida, ChatJuego.Cliente.Proxy.Jugador jugadorInvitador) {
            return base.Channel.enviarInvitacionAsync(jugadorInvitado, codigoPartida, jugadorInvitador);
        }
        
        public ChatJuego.Cliente.Proxy.ChatServicioEstadoDeEnvio mandarCodigoDeRegistro(string codigoDeRegistro, string correo) {
            return base.Channel.mandarCodigoDeRegistro(codigoDeRegistro, correo);
        }
        
        public System.Threading.Tasks.Task<ChatJuego.Cliente.Proxy.ChatServicioEstadoDeEnvio> mandarCodigoDeRegistroAsync(string codigoDeRegistro, string correo) {
            return base.Channel.mandarCodigoDeRegistroAsync(codigoDeRegistro, correo);
        }
    }
}
