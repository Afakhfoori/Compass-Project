import * as React from "react";
import { IOption, IQuestion, QuestionType } from "./../interfaces";

function Question(props: IQuestion) {
  return (
    //export const Question = (props: QuestionType) => (
    <div
      className="border border-secondary rounded mt-3 p-3 shadow-sm"
      key={props.id}
    >
      <div className="mb-0">
        <h5 className="mb-0">{props.title}</h5>
      </div>
      <span>{props.subTitle}</span>
      <div className="mt-4">
        {props.options &&
          props.options
            .sort((a: IOption, b: IOption) => (a.text > b.text ? 1 : -1))
            .map((option: IOption) => (
              <div key={option.id}>
                <input type="checkbox" value={option.text} name="option" />{" "}
                {option.text}
              </div>
            ))}
      </div>
    </div>
  );
}

export default Question;
