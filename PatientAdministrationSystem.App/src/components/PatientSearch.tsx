import React, {useState} from 'react';
import {AiFillInfoCircle} from "react-icons/ai";

import PatientApiService from "../services/patientApiService";
import {VisitInformation} from "../models/visitInformation";

const DEFAULT_ERROR_MESSAGE = 'Oops, something went wrong.';

export interface SearchProps {
    patientApi: PatientApiService;
    handleSearchResult: (patients: VisitInformation[]) => void;
}

function PatientSearch({patientApi, handleSearchResult}: SearchProps) {
    const [email, setEmail] = useState('');
    const [errors, setErrors] = useState<string[]>([]);
    const [hasErrors, setHasErrors] = useState<boolean>(false);
    
    return (
        <div className="flex flex-col items-center justify-center w-3/5">
            <form className="flex flex-col items-center mt-44 flex-grow w-full">
                <div className="flex w-full p-2 hover:shadow-lg focus-within:shadow-lg rounded border">
                    <input type="email"
                           name="email"
                           className="focus:outline-none flex-grow mr-2"
                           placeholder="Enter patient email..."
                           onChange={handleEmailChange}/>
                    <button type="button"
                            name="search"
                            className="bg-blue-900 text-white rounded p-1 items-center justify-between cursor-pointer hover:bg-blue-700"
                            onClick={findPatients}>
                        Search
                    </button>
                </div>
                {
                    hasErrors &&
                    <div className="flex w-3/5 p-4 mt-4 text-base text-white bg-red-400 rounded font-regular">
                        <div className="shrink-0">
                            <AiFillInfoCircle className="h-8"/>
                        </div>
                        <div className="ml-3 mr-12">
                            <p className="block font-sans text-base antialiased font-medium leading-relaxed text-inherit">Errors:</p>
                            <ul className="mt-2 ml-2 list-disc list-inside">
                                {
                                    errors.map(((error, index) => (
                                        <li key={index}>{error}</li>
                                    )))
                                }
                            </ul>
                        </div>
                    </div>
                }                
            </form>
        </div>
    );

    function handleEmailChange(ev: React.FormEvent<HTMLInputElement>): void {
        const {value} = ev.currentTarget;
        setEmail(value);
    }

    function findPatients() {
        setHasErrors(false)
        setErrors([]);
        patientApi.getPatientVisitInformation(email)
            .then(data => {
                handleSearchResult(data);
            })
            .catch(({response}) => {
                if (!response) {
                    setErrors([DEFAULT_ERROR_MESSAGE]);
                } else {
                    const {errors} = response.data;
                    const allErrors = Object.values(errors);
                    if (!allErrors.length) allErrors.push(DEFAULT_ERROR_MESSAGE);

                    setErrors(Object.values(errors))    
                }
                
                setHasErrors(true);
            });
    }
}

export default PatientSearch;