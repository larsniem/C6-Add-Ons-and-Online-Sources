﻿using SwissAcademic.Addons.ReferenceEvaluation.Properties;
using SwissAcademic.Citavi.Shell;
using System.Linq;

namespace SwissAcademic.Addons.ReferenceEvaluation
{
    internal class PersonEvaluator : BaseEvaluator
    {
        #region Properties

        public override string Caption => ReferenceEvaluationResources.PersonEvaluator_Caption;

        #endregion

        #region Methods

        public override string Run(MainForm mainForm)
        {
            _stringBuilder.Clear();

            var persons = mainForm.Project.Persons.ToList();

            if (persons.Count == 0)
            {
                _stringBuilder.AppendLine(ReferenceEvaluationResources.PersonEvaluator_NoPersons);
                return _stringBuilder.ToString();
            }

            persons.Sort(new PersonComparerReferencesCount());
            var maxLength = persons.Max(person => person.FullName.Length);

            if (ShowHeader)
            {
                var headers = ReferenceEvaluationResources.Evaluator_Name
                              + ' '.Repeat(maxLength - ReferenceEvaluationResources.Evaluator_Name.Length + 10)
                              + ReferenceEvaluationResources.Evaluator_Count;
                _stringBuilder.AppendLine(headers);
                _stringBuilder.AppendLine();
            }

            foreach (var person in persons)
            {
                _stringBuilder.AppendLine(person.FullName + ' '.Repeat(maxLength - person.FullName.Length + 10) + person.References.Count);
            }

            return _stringBuilder.ToString();
        }

        #endregion
    }
}