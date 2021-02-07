import React from "react";
import { Route, Switch } from "react-router-dom";
import "./App.css";
import Surveys from "./Components/surveys";
import "bootstrap/dist/css/bootstrap.css";
import axios from "axios";
import { apiEndpoint } from "./config";
import { ISurvey } from "./interfaces";
import { SurveyContext } from "./SurveyContext";
import Survey from "./Components/Survey";

const defaultSurveys: ISurvey[] = [
  {
    id: "1",
    name: "Survey 1",
    questions: [
      {
        id: "53",
        createdBy: "Elisabeth Winters",
        createdDateTime: "Fri, 22 May 2020 01:11:00 GMT",
        title: "How many astronauts landed on the moon?",
        subTitle: "",
        questionType: 3,
        options: [
          {
            id: "1",
            text: "1",
          },
          {
            id: "2",
            text: "3",
          },
          {
            id: "3",
            text: "18",
          },
        ],
      },
      {
        id: "72",
        createdBy: "Maryam O'Ryan",
        createdDateTime: "Tue, 26 May 2020 05:57:52 GMT",
        title: "How many devs does it take to change a lightbulb?",
        subTitle: "This is not a trick question.",
        questionType: 3,
        options: [
          {
            id: "1",
            text: "One",
          },
          {
            id: "2",
            text: "Two",
          },
          {
            id: "3",
            text: "Three thousand three hundred eighty-seven",
          },
        ],
      },
    ],
  },
  {
    id: "2",
    name: "Survey 2",
    questions: [
      {
        id: "34",
        createdBy: "Andre Grid",
        createdDateTime: "Thur, 28 May 2020 09:30:00 GMT",
        title: "What is the temp today?",
        subTitle: "We need to send this to the Bureau of Meteorology.",
        questionType: 3,
        options: [
          {
            id: "1",
            text: "10°",
          },
          {
            id: "2",
            text: "20°",
          },
          {
            id: "3",
            text: "30°",
          },
        ],
      },
    ],
  },
];

function App() {
  const [surveys, setSurveys]: [
    ISurvey[],
    (Surveys: ISurvey[]) => void
  ] = React.useState(defaultSurveys);
  const [loading, setLoading]: [
    boolean,
    (loading: boolean) => void
  ] = React.useState<boolean>(true);
  const [error, setError]: [string, (error: string) => void] = React.useState(
    ""
  );

  React.useEffect(() => {
    console.log(`${apiEndpoint}Surveys`);
    axios
      .get<ISurvey[]>(`${apiEndpoint}Surveys`, {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        console.log(response.data);
        setSurveys(response.data);
        setLoading(false);
      })
      .catch((ex) => {
        const error =
          ex.response && ex.response.status === 404
            ? "Resource not found"
            : "An unexpected error has occurred";
        setError(error);
        setLoading(false);
      });
  }, []);

  return (
    <SurveyContext.Provider value={{ surveys, setSurveys }}>
      <div className="App">
        <div className="container">
          <Switch>
            <Route path="/Survey/:id" component={Survey} />
            <Route path="/" component={Surveys} />
          </Switch>
        </div>
      </div>
    </SurveyContext.Provider>
  );
}

export default App;
