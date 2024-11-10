using Todo.Model;
using Todo.Servico;

namespace Todo.Tests.ServicoTests
{
    public class ProcessaServicoTests
    {
        private readonly ProcessaServico _servico;
        public ProcessaServicoTests()
        {
            _servico = new ProcessaServico();
        }

        [Fact]
        public void CriarTarefa_EnviandoTarefaNula_RetornaValorFalse()
        {
            var resultado = _servico.CriarTarefa(null);

            Assert.False(resultado);
        }

        [Theory]
        [InlineData(Estado.Aguardando, 1, "Criar Aguardando")]
        [InlineData(Estado.Cancelado, 2, "Criar Cancelado")]
        [InlineData(Estado.Concluido, 3, "Criar Concluido")]
        [InlineData(Estado.Executando, 4, "Criar Executando")]
        public void CriarTarefa_EnviandoTarefaPreenchida_RetornaValorTrue(Estado estado, int id, string nome)
        {
            var tarefa = new Tarefa()
            {
                Data = DateTime.Now,
                Estado = estado,
                Id = id,
                Nome = nome
            };

            var resultado = _servico.CriarTarefa(tarefa);

            Assert.True(resultado);
        }

        [Theory]
        [InlineData(Estado.Aguardando, 1, "Criar Aguardando")]
        public void AtualizaTarefa_EnviandoTarefaNull_RetornaValorFalse(Estado estado, int id, string nome)
        {
            var tarefa = new Tarefa()
            {
                Data = DateTime.Now,
                Estado = estado,
                Id = id,
                Nome = nome
            };

            _servico.CriarTarefa(tarefa);

            var resultado = _servico.AtualizaTarefa(null);

            Assert.False(resultado);
        }

        [Theory]
        [InlineData(Estado.Aguardando, 1, "Criar Aguardando")]
        public void AtualizaTarefa_EnviandoTarefaPreenchida_RetornaValorTrue(Estado estado, int id, string nome)
        {
            var tarefa = new Tarefa()
            {
                Data = DateTime.Now,
                Estado = estado,
                Id = id,
                Nome = nome
            };
            var resultado = _servico.CriarTarefa(tarefa);

            tarefa.Estado = Estado.Executando;

            _servico.AtualizaTarefa(tarefa);

            Assert.True(resultado);
        }

        [Theory]
        [InlineData(Estado.Aguardando, 1, "Criar Aguardando")]
        public void RemovendoTarefa_EnviandoTarefaPreenchida_RetornaValorTrue(Estado estado, int id, string nome)
        {
            var tarefa = new Tarefa()
            {
                Data = DateTime.Now,
                Estado = estado,
                Id = id,
                Nome = nome
            };
            _servico.CriarTarefa(tarefa);

            var resultado = _servico.RemoveTarefa(tarefa);

            Assert.True(resultado);
        }

        [Theory]
        [InlineData(Estado.Aguardando, 1, "Criar Aguardando")]
        public void RemovendoTarefa_EnviandoTarefaNull_RetornaValorFalse(Estado estado, int id, string nome)
        {
            var tarefa = new Tarefa()
            {
                Data = DateTime.Now,
                Estado = estado,
                Id = id,
                Nome = nome
            };
            _servico.CriarTarefa(tarefa);

            var resultado = _servico.RemoveTarefa(null);

            Assert.False(resultado);
        }

        [Theory]
        [InlineData(Estado.Aguardando, 1, "Criar Aguardando")]
        public void CarregaTodasAsTarefas_EnviandoTarefaPreenchida_CarregaQuatroItens(Estado estado, int id, string nome)
        {
            var tarefa = new Tarefa()
            {
                Data = DateTime.Now,
                Estado = estado,
                Id = id,
                Nome = nome
            };

            _servico.CriarTarefa(tarefa);
            _servico.CriarTarefa(tarefa);
            _servico.CriarTarefa(tarefa);
            _servico.CriarTarefa(tarefa);

            var resultado = _servico.CarregaTodasAsTarefas();

            Assert.NotEmpty(resultado);
            Assert.Equal(4, resultado.Count());
        }

        [Theory]
        [InlineData(Estado.Aguardando, 1, "Criar Aguardando")]
        public void QuantidadeTarefasPorEstadoEscolhido_EnviandoEstadoAguardando_CarregaQuatroItens(Estado estado, int id, string nome)
        {
            var tarefa = new Tarefa()
            {
                Data = DateTime.Now,
                Estado = estado,
                Id = id,
                Nome = nome
            };

            _servico.CriarTarefa(tarefa);
            _servico.CriarTarefa(tarefa);
            _servico.CriarTarefa(tarefa);
            _servico.CriarTarefa(tarefa);

            var resultado = _servico.QuantidadeTarefasPorEstadoEscolhido(estado);

            Assert.Equal(4, resultado);
        }



        [Theory]
        [InlineData(Estado.Aguardando, 1, "Criar Aguardando", null)]
        [InlineData(Estado.Aguardando, 1, "Criar Aguardando", Estado.Executando)]
        public void QuantidadeTarefasPorEstadoEscolhido_EnviandoEstadoQueNaoContemNaLista_RetornaOValorZero(Estado estado, int id, string nome, Estado estadoEnviado)
        {
            var tarefa = new Tarefa()
            {
                Data = DateTime.Now,
                Estado = estado,
                Id = id,
                Nome = nome
            };

            _servico.CriarTarefa(tarefa);
            _servico.CriarTarefa(tarefa);
            _servico.CriarTarefa(tarefa);
            _servico.CriarTarefa(tarefa);

            var resultado = _servico.QuantidadeTarefasPorEstadoEscolhido(estadoEnviado);

            Assert.Equal(0, resultado);
        }
    }
}
