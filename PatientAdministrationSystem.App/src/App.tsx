import {useState} from "react";

import './App.css'

import PatientSearch from "./components/PatientSearch";
import PatientVisitInformation from "./components/PatientVisitInformation";

import PatientApiService from "./services/patientApiService";
import {VisitInformation} from "./models/visitInformation";

function App() {
    const [data, setData] = useState<VisitInformation[]>([]);
    const [hasResults, setHasResults] = useState<boolean>(false);
    const patientApiService = new PatientApiService();
    
    return (
        <div className="flex flex-col items-center">
            <PatientSearch patientApi={patientApiService} handleSearchResult={handlePatientVisitInformation} />
            <div className="flex flex-col items-start justify-center w-3/5 mt-5">
                {
                    hasResults &&
                    data.map((visitInfo, index) => (
                        <PatientVisitInformation key={index} visitInformation={visitInfo} />
                    ))
                }
            </div>
        </div>
    )

    function handlePatientVisitInformation(results: VisitInformation[]) {
        setData(results);
        setHasResults(!!results.length);
    }
}

export default App
