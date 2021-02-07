import * as React from "react";
import { Link } from "react-router-dom";
import { useSurveys } from './../SurveyContext';


const Surveys = () => {

  const { surveys, setSurveys } = useSurveys();

  return (

    <div className="text-left p-5 ">
      <h1>Comapss Survey</h1>
      <div>
        {surveys.length === 0 && (
          <h3 className="text-danger  text-center bold">
            There are no survey to complete now!
          </h3>
        )}
        {surveys
          .sort((a, b) => (a.name > b.name ? 1 : -1))
          .map((survey) => (
            <Link
              to={{
                pathname: `/Survey/${survey.id}`,
                //data: survey,
              }}
              className="btn border border-secondary rounded w-100 m-1"
              key={survey.id}
            >
              {survey.name}
            </Link>
          ))}
      </div>
    </div>
  
  );
};

export default Surveys;

// class Surveys: () => {}

//     state = {
//         surveys: [
//             {
//               id: "1",
//               name: "Survey 1",
//               questions: [
//                 {
//                   id: "53",
//                   createdBy: "Elisabeth Winters",
//                   createdDateTime: "Fri, 22 May 2020 01:11:00 GMT",
//                   title: "How many astronauts landed on the moon?",
//                   subTitle: "",
//                   questionType: 3,
//                   options: [
//                     {
//                       id: "1",
//                       text: "1",
//                     },
//                     {
//                       id: "2",
//                       text: "3",
//                     },
//                     {
//                       id: "3",
//                       text: "18",
//                     },
//                   ],
//                 },
//                 {
//                   id: "72",
//                   createdBy: "Maryam O'Ryan",
//                   createdDateTime: "Tue, 26 May 2020 05:57:52 GMT",
//                   title: "How many devs does it take to change a lightbulb?",
//                   subTitle: "This is not a trick question.",
//                   questionType: 3,
//                   options: [
//                     {
//                       id: "1",
//                       text: "One",
//                     },
//                     {
//                       id: "2",
//                       text: "Two",
//                     },
//                     {
//                       id: "3",
//                       text: "Three thousand three hundred eighty-seven",
//                     },
//                   ],
//                 },
//               ],
//             },
//             {
//               id: "2",
//               name: "Survey 2",
//               questions: [
//                 {
//                   id: "34",
//                   createdBy: "Andre Grid",
//                   createdDateTime: "Thur, 28 May 2020 09:30:00 GMT",
//                   title: "What is the temp today?",
//                   subTitle: "We need to send this to the Bureau of Meteorology.",
//                   questionType: 3,
//                   options: [
//                     {
//                       id: "1",
//                       text: "10°",
//                     },
//                     {
//                       id: "2",
//                       text: "20°",
//                     },
//                     {
//                       id: "3",
//                       text: "30°",
//                     },
//                   ],
//                 },
//               ],
//             },
//           ]
//     }

//     async componentDidMount() {
//         const { surveys: Surveys } = await (await axios.get(`${apiEndpoint}Surveys`)).data;
//         this.setState({ surveys });
//       }

//       render() {
//         return (
//           <div className="text-left p-5 ">
//             <h1>Comapss Survey</h1>
//             <div>
//               {this.state.surveys.length === 0 && (
//                 <h3 className="text-danger  text-center bold">
//                   There are no survey to complete now!
//                 </h3>
//               )}
//               {this.state.surveys
//                 .sort((a, b) => (a.name > b.name ? 1 : -1))
//                 .map((survey) => (
//                   <Link
//                     to={{
//                       pathname: `/Survey/${survey.id}`,
//                       data: survey,
//                     }}
//                     className="btn border border-secondary rounded w-100 m-1"
//                     key={survey.id}
//                   >
//                     {survey.name}
//                   </Link>
//                 ))}
//             </div>
//           </div>
//         );
//       }

// }
//   state = {
//     surveys: [
//       {
//         id: "1",
//         name: "Survey 1",
//         questions: [
//           {
//             id: "53",
//             createdBy: "Elisabeth Winters",
//             createdDateTime: "Fri, 22 May 2020 01:11:00 GMT",
//             title: "How many astronauts landed on the moon?",
//             subTitle: "",
//             questionType: 3,
//             options: [
//               {
//                 id: "1",
//                 text: "1",
//               },
//               {
//                 id: "2",
//                 text: "3",
//               },
//               {
//                 id: "3",
//                 text: "18",
//               },
//             ],
//           },
//           {
//             id: "72",
//             createdBy: "Maryam O'Ryan",
//             createdDateTime: "Tue, 26 May 2020 05:57:52 GMT",
//             title: "How many devs does it take to change a lightbulb?",
//             subTitle: "This is not a trick question.",
//             questionType: 3,
//             options: [
//               {
//                 id: "1",
//                 text: "One",
//               },
//               {
//                 id: "2",
//                 text: "Two",
//               },
//               {
//                 id: "3",
//                 text: "Three thousand three hundred eighty-seven",
//               },
//             ],
//           },
//         ],
//       },
//       {
//         id: "2",
//         name: "Survey 2",
//         questions: [
//           {
//             id: "34",
//             createdBy: "Andre Grid",
//             createdDateTime: "Thur, 28 May 2020 09:30:00 GMT",
//             title: "What is the temp today?",
//             subTitle: "We need to send this to the Bureau of Meteorology.",
//             questionType: 3,
//             options: [
//               {
//                 id: "1",
//                 text: "10°",
//               },
//               {
//                 id: "2",
//                 text: "20°",
//               },
//               {
//                 id: "3",
//                 text: "30°",
//               },
//             ],
//           },
//         ],
//       },
//     ],
//   };

//   async componentDidMount() {
//     const { data: surveys } = await axios.get(`${apiEndpoint}Surveys`);
//     this.setState({ surveys });
//   }

//   render() {
//     return (
//       <div className="text-left p-5 ">
//         <h1>Comapss Survey</h1>
//         <div>
//           {this.state.surveys.length === 0 && (
//             <h3 className="text-danger  text-center bold">
//               There are no survey to complete now!
//             </h3>
//           )}
//           {this.state.surveys
//             .sort((a, b) => (a.name > b.name ? 1 : -1))
//             .map((survey) => (
//               <Link
//                 to={{
//                   pathname: `/Survey/${survey.id}`,
//                   data: survey,
//                 }}
//                 className="btn border border-secondary rounded w-100 m-1"
//                 key={survey.id}
//               >
//                 {survey.name}
//               </Link>
//             ))}
//         </div>
//       </div>
//     );
//   }
// }

// export default Surveys;
