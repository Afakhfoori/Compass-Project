import { createContext, useContext } from 'react';

import { ISurvey } from './interfaces';

const defaultSurveys: ISurvey[] = []

export type  SurveyContextType = {
    surveys: ISurvey[];
    setSurveys: (Surveys: ISurvey[]) => void;
}

export const  SurveyContext = createContext<SurveyContextType>({ surveys:defaultSurveys, setSurveys: defaulSurveys => console.warn('No surveys provided')});
export const useSurveys = () => useContext(SurveyContext);