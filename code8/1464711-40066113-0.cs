    public class Agenda
    {
        public int CodigoClinica { get; set; }
        public int CodigoConvenio { get; set; }
        public int CodigoPaciente { get; set; }
        public int CodigoProfissional { get; set; }
        public int CodigoTipoAgendamento { get; set; }
        public int CodigoProcedimento { get; set; }
        public DateTime DataAgenda { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataInclusao { get; set; }
        public string HoraFim { get; set; }
        public string HoraInicio { get; set; }
        public object Observacao { get; set; }
        public int Status { get; set; }
        public string StatusDescricao { get; set; }
        public string Cor { get; set; }
        public string NomePaciente { get; set; }
        public string NomeProfissional { get; set; }
        public object NomeProcedimento { get; set; }
        public int CodigoProfissionalUsuario { get; set; }
        public int Codigo { get; set; }
        public bool Excluido { get; set; }
    }
    public class Profissionai
    {
        public string Nome { get; set; }
        public object Apelido { get; set; }
        public object CNPJOuCPF { get; set; }
        public int CodigoClinica { get; set; }
        public object CodigoTipoDocProfissional { get; set; }
        public object Documento { get; set; }
        public object CEP { get; set; }
        public object Endereco { get; set; }
        public object Complemento { get; set; }
        public object Numero { get; set; }
        public object Bairro { get; set; }
        public object Municipio { get; set; }
        public object UF { get; set; }
        public int CodigoTipoProfissional { get; set; }
        public string DocumentoUF { get; set; }
        public string Email { get; set; }
        public object DataNascimento { get; set; }
        public object Sexo { get; set; }
        public object Observacao { get; set; }
        public int Faltas { get; set; }
        public int Atendimentos { get; set; }
        public int CodigoConselho { get; set; }
        public string CRM { get; set; }
        public int Codigo { get; set; }
        public bool Excluido { get; set; }
    }
    public class Telefone
    {
        public int CodigoClinica { get; set; }
        public string NumeroTelefone { get; set; }
        public int CodigoTipoTelefone { get; set; }
        public int Codigo { get; set; }
        public bool Excluido { get; set; }
    }
    public class Convenio
    {
        public int CodigoClinica { get; set; }
        public int CodigoSequencial { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public int Codigo { get; set; }
        public bool Excluido { get; set; }
    }
    public class Paciente
    {
        public object Bairro { get; set; }
        public object CEP { get; set; }
        public object CPF { get; set; }
        public string Celular { get; set; }
        public int CodigoClinica { get; set; }
        public object Complemento { get; set; }
        public object Email { get; set; }
        public object Endereco { get; set; }
        public object Municipio { get; set; }
        public string Nome { get; set; }
        public object Numero { get; set; }
        public string Telefone { get; set; }
        public object UF { get; set; }
        public object DataNascimento { get; set; }
        public object Faltas { get; set; }
        public string Sexo { get; set; }
        public bool LiberaAtendimento { get; set; }
        public int Codigo { get; set; }
        public bool Excluido { get; set; }
    }
    public class FinanceiroCategoria
    {
        public int CodigoClinica { get; set; }
        public string Descricao { get; set; }
        public int Codigo { get; set; }
        public bool Excluido { get; set; }
    }
    public class FinanceiroSubCategoria
    {
        public int CodigoClinicaCategoria { get; set; }
        public int CodigoClinica { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Cor { get; set; }
        public int Codigo { get; set; }
        public bool Excluido { get; set; }
    }
    public class FormaPagamento
    {
        public int CodigoClinica { get; set; }
        public int CodigoFormaPagamento { get; set; }
        public object CodigoFormaPagamentoPai { get; set; }
        public int CodigoUsuario { get; set; }
        public string Nome { get; set; }
        public int Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int Codigo { get; set; }
        public bool Excluido { get; set; }
    }
    public class Dados
    {
        public IList<Agenda> Agendas { get; set; }
        public IList<Profissionai> Profissionais { get; set; }
        public IList<Telefone> Telefones { get; set; }
        public IList<Convenio> Convenios { get; set; }
        public IList<Paciente> Pacientes { get; set; }
        public IList<FinanceiroCategoria> FinanceiroCategorias { get; set; }
        public IList<FinanceiroSubCategoria> FinanceiroSubCategorias { get; set; }
        public IList<FormaPagamento> FormaPagamentos { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public object CNES { get; set; }
        public string CNPJCPF { get; set; }
        public object Complemento { get; set; }
        public object Email { get; set; }
        public string Endereco { get; set; }
        public string Municipio { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string UF { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Codigo { get; set; }
        public bool Excluido { get; set; }
    }
    public class Example
    {
        public int CodigoRetorno { get; set; }
        public string Mensagem { get; set; }
        public Dados Dados { get; set; }
    }
