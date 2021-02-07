export interface IOption {
    id: string;
    text: string;
  }
  
 export interface IQuestion {
    id: string;
    createdBy: string;
    createdDateTime: string;
    title: string;
    subTitle: string;
    questionType: number;
    options:IOption[];
  }

  export type QuestionType = {
    id: string;
    createdBy: string;
    createdDateTime: string;
    title: string;
    subTitle: string;
    questionType: number;
    options:IOption[];
  }
  
  export interface ISurvey {
    id: string;
    name: string;
    questions: IQuestion[];
  }

