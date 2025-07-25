﻿using Gerador_de_testes.ModuloQuestao;
using Gerador_de_testes.WebApp.Models;

namespace Gerador_de_testes.WebApp.Extensions
{
    public static class QuestaoExtensions
    {
        public static Questao ParaEntidade(this FormularioQuestaoViewModel formularioVM)
        {
            return new Questao(formularioVM.Enunciado!);
        }
        public static Alternativa ParaEntidadeAlternativa(this CadastrarAlternativaViewModel cadastrarVm) => new Alternativa(cadastrarVm.Resposta!, cadastrarVm.Correta, cadastrarVm.Questao);

        public static DetalhesQuestaoViewModel ParaDetalhesVM(this Questao questao)
        {
            return new DetalhesQuestaoViewModel(
                    questao.Id,
                    questao.Enunciado,
                    questao.Materia,
                    questao.Alternativas
            );
        }
    }
}
