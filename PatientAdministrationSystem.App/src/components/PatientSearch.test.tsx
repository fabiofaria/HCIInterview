import {render, screen} from '@testing-library/react'
import user from '@testing-library/user-event';

import PatientSearch, {SearchProps} from './PatientSearch'
import PatientApiService from '../services/patientApiService';

describe('PatientSearch', () => {
    const apiService = new PatientApiService();
    apiService.getPatientVisitInformation = jest.fn();

    const props: SearchProps = {
        patientApi: apiService,
        handleSearchResult: jest.fn
    }

    test('search for patient', async () => {
        user.setup();
        render(<PatientSearch patientApi={props.patientApi} handleSearchResult={props.handleSearchResult} />)

        const searchButton = screen.getByRole('button');
        const emailInput = screen.getByRole('textbox');

        expect(searchButton).toBeInTheDocument();
        expect(emailInput).toBeInTheDocument();
    })
})