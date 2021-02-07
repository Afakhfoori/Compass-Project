import * as React from "react";
import { Link, RouteComponentProps } from "react-router-dom";
import { useSurveys } from "./../SurveyContext";
import Question from "./question";

type TParams = { id: string };

function Survey({ match }: RouteComponentProps<TParams>) {
  const { surveys, setSurveys } = useSurveys();
  const survey = surveys.filter((Survey) => Survey.id === match.params.id)[0];

  return (
    <div className="text-left p-5 ">
      <h1>{survey.name}</h1>
      <div>
        {survey.questions &&
          survey.questions
            .sort((a, b) => (a.title > b.title ? 1 : -1))
            .map((question) => (
              <Question
                id={question.id}
                title={question.title}
                subTitle={question.subTitle}
                createdBy={question.createdBy}
                createdDateTime={question.createdDateTime}
                options={question.options}
                questionType={question.questionType}
              />
            ))}
      </div>
      <div className="mt-3">
        <Link
          to="/surveys"
          className="btn border border-secondary rounded float-right"
        >
          Back
        </Link>
      </div>
    </div>
  );
}

export default Survey;
