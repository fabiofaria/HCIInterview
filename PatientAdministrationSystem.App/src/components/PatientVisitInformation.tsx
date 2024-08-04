import {VisitInformation} from "../models/visitInformation";

interface PatientVisitInformationProps {
    visitInformation: VisitInformation;
}

function PatientVisitInformation({ visitInformation }: PatientVisitInformationProps) {
    return (
        <div className="flex flex-col border rounded p-2 shadow">
                    <div className="text-gray-900 font-bold text-xl mb-2">{visitInformation.patientName}</div>
                    <div>
                        <span className="font-bold">Hospital: </span>
                        <span>{visitInformation.hospitalName}</span>
                    </div>
                    <div>
                        <span className="font-bold">Visit: </span>
                        <span>{visitInformation.visitDate.toLocaleString()}</span>
                    </div>
        </div>
    );
}

export default PatientVisitInformation;